import { Component, Input, Injector, OnInit } from '@angular/core';
import { NDDSidebarComponent } from '../';

@Component({
    selector: 'ndd-ng-sidebar-suboption',
    templateUrl: 'ndd-ng-sidebar-suboption.component.html',
})
export class NDDSidebarSuboptionComponent implements OnInit {

    @Input() public subOptionId: string;
    @Input() public subOptionText: string;
    @Input() public subOptionHref: string;

    public isSelected: boolean;

    public nddSidebar: NDDSidebarComponent;
    public subOptionI18n: boolean;

    constructor(injector: Injector) {
        this.nddSidebar = injector.get(NDDSidebarComponent);
    }

    public ngOnInit(): void {
        this.subOptionI18n = this.nddSidebar.sidebarI18n;
    }

}
