import {
    Component,
    Input,
    Output,
    EventEmitter,
    ContentChildren,
    QueryList,
    OnInit,
    AfterContentInit,
    HostListener,
    ElementRef,
    Inject,
} from '@angular/core';

import {
    Router,
    ActivatedRoute,
    NavigationEnd,
} from '@angular/router';

import {
    NDDSidebarOptionComponent,
    NDDSidebarSuboptionComponent,
    NDDSidebarSubmenuGroupComponent,
    NDDSidebarService,
} from './';

@Component({
    selector: 'ndd-ng-sidebar',
    templateUrl: 'ndd-ng-sidebar.component.html',
})
export class NDDSidebarComponent implements OnInit, AfterContentInit {

    private static WINDOW_WIDTH: number = 768;

    @Input() public sidebarHeader: boolean;

    @Input() public sidebarIconIndent?: string;
    @Input() public sidebarIconOutdent?: string;

    @Input() public sidebarI18n: boolean;

    @Output() public onSidebarPin: EventEmitter<boolean> = new EventEmitter();

    public isExpand: boolean = false;
    public isSubmenuShow: boolean = false;
    public isMenuExpand: boolean = false;

    @ContentChildren(NDDSidebarOptionComponent) public menuItems: QueryList<NDDSidebarOptionComponent>;
    @ContentChildren(NDDSidebarSubmenuGroupComponent) public submenuGroups: QueryList<NDDSidebarSubmenuGroupComponent>;

    public pinned: boolean = false;
    private cachePin: boolean = false;
    private cancelPin: boolean = false;

    private toggleFromService: boolean = false;

    private url: string;

    constructor(
        private sidebarService: NDDSidebarService,
        private router: Router,
        private ref: ElementRef,
        @Inject(Window) private windowRef: Window,
    ) { }

    public ngOnInit(): void {
        this.sidebarService.register(this);

        this.router.events
            .filter((event: any) => event instanceof NavigationEnd)
            .subscribe((event: NavigationEnd) => {
                this.url = event.urlAfterRedirects;
                this.setSelection();
            });
    }

    public ngAfterContentInit(): void {
        this.url = this.windowRef.location.pathname;

        this.setSelection();
    }

    public getCollapseIcon(): string {
        if ((this.isSubmenuShow && !this.pinned) || this.isMenuExpand) {
            return this.sidebarIconIndent || 'ndd-font ndd-font-indent';
        } else {
            return this.sidebarIconOutdent || 'ndd-font ndd-font-outdent';
        }
    }

    public toggleCollapseSidebar(fromService: boolean): void {
        this.toggleFromService = fromService;
        this.isMenuExpand = this.isSubmenuShow && !this.pinned ? false : !this.isMenuExpand;
        this.isSubmenuShow = this.pinned;
        this.isExpand = this.isMenuExpand || this.isSubmenuShow;
        this.clearOptions(false, !this.isSubmenuShow, !this.isSubmenuShow);
    }

    public selectOption(toSelectOption: NDDSidebarOptionComponent): void {
        const isOptionLink: Function = (): void => {
            // Despina e emite o evento de pin == false
            this.cancelPin = !toSelectOption.isSelected;
            // Vai para a rota
            this.router.navigate([toSelectOption.optionHref]);
        };

        const isOptionMenu: Function = (): void => {
            // Se está aberto, e não fechamos o submenu
            if (toSelectOption.isOpen && !this.isMenuExpand && !this.pinned) {
                this.pinned = false;
                this.isExpand = false;
                this.isSubmenuShow = false;
                toSelectOption.isFocused = false;
                toSelectOption.isOpen = false;
            } else {
                this.cancelPin = false;
                this.pinned = this.cachePin;
                this.clearOptions(false, true, true);
                this.showSubmenu(toSelectOption.optionId);
                toSelectOption.isFocused = true;
                toSelectOption.isOpen = true;
                this.onSidebarPin.emit(this.pinned);
            }
        };

        // Caso tenha um href então é uma opção de link então chama isOptionLink() para redirecionar
        // Senão, é um menu então chama isOptionMenu() para abrir o submenu
        toSelectOption.optionHref ? isOptionLink() : isOptionMenu();
    }

    public selectSuboption(toSelectSuboption: NDDSidebarSuboptionComponent): void {
        this.cancelPin = false;
        this.router.navigate([toSelectSuboption.subOptionHref]);
        if (window.innerWidth < NDDSidebarComponent.WINDOW_WIDTH) {
            this.toggleCollapseSidebar(false);
        }
    }

    public showSubmenu(target: string): void {
        // Define como visível um submenu com base em um @optionTarget.
        // @optionTarget é o id do submenu que deseja ser visível.
        this.submenuGroups.forEach((group: NDDSidebarSubmenuGroupComponent) => {
            if (group.groupTarget === target) {
                this.isSubmenuShow = true;
                this.isExpand = true;
                this.isMenuExpand = false;
                group.groupVisible = true;
            } else {
                group.groupVisible = false;
            }
        });
    }

    public pinSubmenu(): void {
        this.pinned = !this.pinned;
        // Atualiza o cache
        this.cachePin = this.pinned;
        this.onSidebarPin.emit(this.pinned);
    }

    @HostListener('document:click', ['$event']) public docClick(event: any): void {
        if (!this.ref.nativeElement.contains(event.target)) {
            this.onOffClick();
        }
    }

    private onOffClick(): void {
        if (!this.pinned && this.isExpand && !this.toggleFromService) {
            this.toggleCollapseSidebar(false);
        }
        this.toggleFromService = false;
    }

    private clearOptions(clearSelect: boolean, clearFocus: boolean, clearOpen: boolean): void {
        // Limpa a seleção/foco/abertura de menu de todas as opções do menu principal.
        this.menuItems.map((option: NDDSidebarOptionComponent) => {
            clearSelect ? option.isSelected = false : '';
            clearFocus ? option.isFocused = false : '';
            clearInterval ? option.isOpen = false : '';
        });
    }

    private setSelection(): void {
        this.clearSelectionSuboptions();
        if (this.cancelPin) {
            this.pinned = false;
            this.cancelPin = false;
            this.onSidebarPin.emit(this.pinned);
        }
        // O sidebar fica expandido e/ou com o submenu mostrando apenas se pinado
        this.checkSelected(this.pinned);
        this.checkFocus();
        this.isExpand = this.pinned;
        this.isSubmenuShow = this.pinned;
        // Ao trocar de rota, o menu principal fica sempre contraído.
        this.isMenuExpand = false;
    }

    private clearSelectionSuboptions(): void {
        // Limpa a seleção de todas as opções dos submenus.
        this.submenuGroups.forEach((group: NDDSidebarSubmenuGroupComponent) => {
            group.submenuOptions.forEach((suboption: NDDSidebarSuboptionComponent): void => {
                suboption.isSelected = false;
            });
        });
    }

    private checkSelected(openSubmenu: any): void {
        // Verifica o selecionado com base em uma opção
        // @param openSubmenu indica se ao definir selecionado deve abrir o submenu ou não.

        this.menuItems.forEach((option: NDDSidebarOptionComponent) => {
            if (option.optionHref === this.url || this.isParentSelected(option)) {
                this.clearOptions(true, !this.pinned, false);
                option.isSelected = true;
                option.isFocused = true;

                return;
            }
            const childSelected: any = this.isChildSelected(option);
            if (childSelected.suboption) {
                this.clearOptions(true, true, false);
                option.isSelected = true;
                option.isFocused = true;
                childSelected.suboption.isSelected = true;
                option.isOpen = !!openSubmenu;
                openSubmenu && this.showSubmenu(childSelected.target);

                return;
            }
        });
    }

    private isParentSelected(option: NDDSidebarOptionComponent | NDDSidebarSuboptionComponent): boolean {
        // Verifica se tem alguma rota pai selecionada com base na rota da opção.
        // Útil para rotas de edição, exemplo:
        // App.printer.register, app.printer.list (considerando a rota da opção como app.priter)
        let root: ActivatedRoute = this.router.routerState.root;
        while (root !== undefined && root !== null) {
            if (option instanceof NDDSidebarOptionComponent) {
                if (option.optionHref === '/' + root.snapshot.url.join('/')) {
                    return true;
                } else {
                    root = root.firstChild;
                }
            } else {
                if (option.subOptionHref === '/' + root.snapshot.url.join('/')) {
                    return true;
                } else {
                    root = root.firstChild;
                }
            }
        }

        return false;
    }

    private isChildSelected(option: NDDSidebarOptionComponent): { suboption: NDDSidebarSuboptionComponent, target: string } {
        // Verifica se tem alguma opção do submenu selecionada de uma opção do menu principal
        let suboptionReturn: NDDSidebarSuboptionComponent = undefined;
        let suboptionTarget: string = undefined;

        this.submenuGroups.forEach((group: NDDSidebarSubmenuGroupComponent) => {
            group.submenuOptions.forEach((suboption: NDDSidebarSuboptionComponent) => {
                if (group.groupTarget === option.optionId
                    && (this.url.startsWith(suboption.subOptionHref) || this.isParentSelected(suboption))) {
                    suboptionReturn = suboption;
                    suboptionTarget = group.groupTarget;

                    return;
                }
            });
        });

        return { suboption: suboptionReturn, target: suboptionTarget };
    }

    private checkFocus(): void {
        this.menuItems.forEach((option: NDDSidebarOptionComponent) => {
            option.isFocused = option.isOpen;
        });
    }

}
