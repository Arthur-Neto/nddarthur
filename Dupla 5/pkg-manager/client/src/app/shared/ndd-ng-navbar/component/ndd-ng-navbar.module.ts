import { NgModule } from '@angular/core';
import { NDDBreadcrumbModule } from '../../ndd-ng-breadcrumb';

import { NDDNavbarComponent } from './ndd-ng-navbar.component';

@NgModule({
    imports: [NDDBreadcrumbModule],
    exports: [NDDNavbarComponent],
    declarations: [NDDNavbarComponent],
})
export class NDDNavbarModule { }
