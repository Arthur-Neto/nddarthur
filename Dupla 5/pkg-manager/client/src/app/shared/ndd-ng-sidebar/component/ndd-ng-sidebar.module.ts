import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {
    NDDSidebarComponent,
    NDDSidebarOptionComponent,
    NDDSidebarSubmenuGroupComponent,
    NDDSidebarSuboptionComponent,
    NDDSidebarService,
} from './';

@NgModule({
    imports: [
        CommonModule,
    ],
    exports: [
        NDDSidebarComponent,
        NDDSidebarOptionComponent,
        NDDSidebarSubmenuGroupComponent,
        NDDSidebarSuboptionComponent,
    ],
    declarations: [
        NDDSidebarComponent,
        NDDSidebarOptionComponent,
        NDDSidebarSubmenuGroupComponent,
        NDDSidebarSuboptionComponent,
    ],
    providers: [NDDSidebarService],
})
export class NDDSidebarModule { }
