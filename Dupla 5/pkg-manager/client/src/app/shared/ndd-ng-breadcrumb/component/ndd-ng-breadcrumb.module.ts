import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

import { NDDBreadcrumbComponent } from './ndd-ng-breadcrumb.component';
import { NDDBreadcrumbPopupComponent } from './breadcrumb-popup/ndd-ng-breadcrumb-popup.component';
import { NDDBreadcrumbService, NDDBreadcrumbDOMService } from './ndd-ng-breadcrumb.service';
import { NDDBreadcrumbResizeDirective } from './ndd-ng-breadcrumb-resize.directive';
import { NDDBreadcrumbStore } from './ndd-ng-breadcrumb-store.service';

@NgModule({
    imports: [
        RouterModule,
        CommonModule,
    ],
    exports: [NDDBreadcrumbComponent, NDDBreadcrumbPopupComponent],
    declarations: [NDDBreadcrumbComponent, NDDBreadcrumbPopupComponent, NDDBreadcrumbResizeDirective],
    providers: [NDDBreadcrumbStore, NDDBreadcrumbService, NDDBreadcrumbDOMService],
})
export class NDDBreadcrumbModule { }
