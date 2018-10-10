import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoadingBarRouterModule } from '@ngx-loading-bar/router';

import { SharedModule } from '../../shared/shared.module';
import { LayoutComponent } from './layout.component';
import { NDDSidebarModule } from '../../shared/ndd-ng-sidebar';
import { NDDNavbarModule } from '../../shared/ndd-ng-navbar';

@NgModule({
    imports: [
        SharedModule,
        RouterModule,
        // Temp
        NDDNavbarModule,
        NDDSidebarModule,
        LoadingBarRouterModule,
    ],
    exports: [],
    declarations: [LayoutComponent],
})
export class LayoutModule { }
