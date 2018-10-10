import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NDDTitlebarComponent } from './ndd-ng-titlebar.component';
import { NDDTitlebarInfoComponent } from './ndd-ng-titlebar-info/ndd-ng-titlebar-info.component';

@NgModule({
    imports: [
        CommonModule,
    ],
    exports: [NDDTitlebarComponent],
    declarations: [
        NDDTitlebarInfoComponent,
        NDDTitlebarComponent,
    ],
})
export class NDDTitlebarModule { }
