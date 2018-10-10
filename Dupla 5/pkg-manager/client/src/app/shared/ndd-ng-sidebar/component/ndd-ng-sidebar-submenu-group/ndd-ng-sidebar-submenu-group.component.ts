import { Component, Input, OnInit, ContentChildren, QueryList, Injector, forwardRef } from '@angular/core';
import { NDDSidebarComponent, NDDSidebarSuboptionComponent } from '../';

@Component({
    selector: 'ndd-ng-sidebar-submenu-group',
    templateUrl: 'ndd-ng-sidebar-submenu-group.component.html',
})
export class NDDSidebarSubmenuGroupComponent implements OnInit {

    @Input() public groupTarget: string;
    @Input() public groupHeader: string;

    public groupVisible: boolean;
    public groupI18n: boolean;

    // tslint:disable-next-line:no-forward-ref
    @ContentChildren(forwardRef(() => NDDSidebarSuboptionComponent))
    public submenuOptions: QueryList<NDDSidebarSuboptionComponent>;

    public nddSidebar: NDDSidebarComponent;

    constructor(injector: Injector) {
        this.nddSidebar = injector.get(NDDSidebarComponent);
    }

    public ngOnInit(): void {
        this.groupI18n = this.nddSidebar.sidebarI18n;
    }

}
