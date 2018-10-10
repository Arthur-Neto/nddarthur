import { Injectable } from '@angular/core';
import { NDDSidebarComponent } from '../';

@Injectable()
export class NDDSidebarService {

    private sidebar: NDDSidebarComponent;

    public register(sidebar: NDDSidebarComponent): void {
        this.sidebar = sidebar;
    }

    public toggleCollapse(): void {
        this.sidebar.toggleCollapseSidebar(true);
    }

}
