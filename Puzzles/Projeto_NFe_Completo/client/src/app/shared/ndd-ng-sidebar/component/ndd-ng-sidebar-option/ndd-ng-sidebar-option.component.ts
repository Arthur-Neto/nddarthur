import { Component, Input, Injector, OnInit } from '@angular/core';
import { NDDSidebarComponent } from '../';

@Component({
    selector: 'ndd-ng-sidebar-option',
    templateUrl: 'ndd-ng-sidebar-option.component.html',
})
export class NDDSidebarOptionComponent implements OnInit {

    @Input() public optionId: string;

    @Input() public optionText: string;
    @Input() public optionIcon: string;

    @Input() public optionHref: string;

    public isSelected: boolean;
    public isFocused: boolean;
    public isOpen: boolean;

    public nddSidebar: NDDSidebarComponent;
    public optionI18n: boolean;

    constructor(injector: Injector) {
        this.nddSidebar = injector.get(NDDSidebarComponent);
    }

    public ngOnInit(): void {
        this.optionI18n = this.nddSidebar.sidebarI18n;
    }

}
