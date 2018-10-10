import { Component } from '@angular/core';
import { NDDSidebarService } from '../../shared/ndd-ng-sidebar';

@Component({
    selector: 'ndd-layout',
    templateUrl: './layout.component.html',
})
export class LayoutComponent {
    public pinned: boolean = false;

    constructor(
        private sidebarService: NDDSidebarService,
    ) { }

    public setPin(pinned: boolean): void {
        this.pinned = pinned;
    }

    public toggleSidebar(): void {
        this.sidebarService.toggleCollapse();
    }
}
