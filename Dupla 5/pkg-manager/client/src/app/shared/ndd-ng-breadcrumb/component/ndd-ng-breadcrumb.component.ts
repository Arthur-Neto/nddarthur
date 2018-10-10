import {
    Component,
    OnInit,
    OnDestroy,
    Input,
    ElementRef,
    HostListener,
    ChangeDetectorRef,
} from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs/Subject';

import { INDDBreadcrumb } from './ndd-ng-breadcrumb.model';
import { NDDBreadcrumbSelectors } from './ndd-ng-breadcrumb.enum';
import { NDDBreadcrumbService, NDDBreadcrumbDOMService } from './ndd-ng-breadcrumb.service';
import { NDDBreadcrumbStore } from './ndd-ng-breadcrumb-store.service';

@Component({
    selector: 'ndd-ng-breadcrumb',
    templateUrl: './ndd-ng-breadcrumb.component.html',
})

/*
 * Componente de breadcrumb
 *
 * Esse componente é responsável por ler a árvore de rotas da aplicação
 * e em cada rota obter os parâmetros de breadcrumb para exibir no componente.
 *
 */
export class NDDBreadcrumbComponent implements OnInit, OnDestroy {
    @Input() public breadcrumbI18n: boolean = false;
    @Input() public breadcrumbStartLinkDisabled: boolean = true;
    @Input() public breadcrumbHomeName?: string;
    public isOpenMenu: boolean = false;
    public breadcrumbs: INDDBreadcrumb[] = [];
    public hiddenBreadcrumbs: INDDBreadcrumb[] = [];

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    private refContent: any;

    constructor(
        private router: Router,
        private ref: ElementRef,
        private cdr: ChangeDetectorRef,
        private breadcrumbService: NDDBreadcrumbService,
        private breadcrumbDOMService: NDDBreadcrumbDOMService,
        private breadcrumbStore: NDDBreadcrumbStore,
    ) { }

    public ngOnInit(): void {
        this.router.events
            .takeUntil(this.ngUnsubscribe)
            .subscribe(() => {
                this.isOpenMenu = false;
            });

        this.breadcrumbService.onModelChange
            .takeUntil(this.ngUnsubscribe)
            .subscribe((data: INDDBreadcrumb[]) => this.resetBreadcrumb());

        this.refContent = this.ref.nativeElement.querySelector(NDDBreadcrumbSelectors.content);
    }
    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    @HostListener('document:click', ['$event']) public docClick(event: Event): void {
        // Se clicou fora do breadcrumb, o menu deve ser fechado
        if (!this.ref.nativeElement.contains(event.target)) {
            this.isOpenMenu = false;
        }
    }
    @HostListener('window:resize', ['$event']) public onResize(event: Event): void {
        // Se o menu estiver aberto, fecha para não causar erros de cáculo
        this.isOpenMenu = false;
        // Redefine os ponteiros do breadcrumb
        this.resetBreadcrumb(true);
    }

    /**
     * Método invocado pela diretiva ndd-ng-breadcrumb-resize
     * que adiciona os elementos na store e
     * invoca o redimensionamento a cada elemento novo inserido
     */
    public addBreadcrumb(element: ElementRef, isFixed: boolean = false): void {
        this.breadcrumbStore.add(element, isFixed);
        this.resizeBreadcrumb();
    }

    /**
     * Método invocado pela diretiva ndd-ng-breadcrumb-resize
     * que remove os elementos na store e
     * invoca o redimensionamento a cada elemento novo inserido
     */
    public removeBreadcrumb(element: ElementRef, isFixed: boolean = false): void {
        this.breadcrumbStore.remove(element, isFixed);
        this.resizeBreadcrumb();
    }

    /**
     * Método para abrir/fechar o menu de opções
     */
    public toggleMenu(): void {
        this.isOpenMenu = !this.isOpenMenu;
    }

    /**
     * Método para limpar os caches e ponteiros do breadcrumb
     */
    private resetBreadcrumb(newModels: boolean = false): void {
        // Limpa o cache
        this.breadcrumbStore.clean();
        // Limpa o menu
        this.hiddenBreadcrumbs = [];

        if (newModels) {
            // Precisamos gerar novos objetos para o angular refazer o breadcrumb
            // Se manter a mesma referência, ele identifica que não há mudanças e não refaz
            // Isso apenas no resize do window é necessário (queremos renderizar tudo novamente)
            this.breadcrumbs = this.breadcrumbStore.getAllModelsWithNewRef();
        } else {
            // Aqui usamos o slice() para criar outra referencia de array mas com os mesmos objetos
            // Assim, temos organizações diferentes para os mesmos objetos.
            // O breadcrumbsCache não pode ser alterado pois ele é a fonte dos dados para distribuir/resturar conforme espaço
            this.breadcrumbs = this.breadcrumbStore.getAllModels();
        }
    }

    /**
     * Método para redimensionar o breadcrumb conforme a largura do elemento pai
     */
    private resizeBreadcrumb(): void {
        const breadcrumbElements: ElementRef[] = this.breadcrumbStore.getElements();
        const breadcrumbs: INDDBreadcrumb[] = this.breadcrumbStore.getAllModels();
        // Apenas no último elemento que será aplicado a distribuição
        if (!this.refContent || breadcrumbElements.length !== breadcrumbs.length) return;
        const totalToRemove: number = this.breadcrumbDOMService.getNumberElementsToRemove(this.refContent);
        this.hiddenBreadcrumbs = breadcrumbs.splice(0, totalToRemove);
        this.breadcrumbs = breadcrumbs;
        this.cdr.detectChanges();
    }
}
