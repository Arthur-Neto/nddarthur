import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { NDDTabComponent, NDDTabsbarComponent } from './';

@NgModule({
    imports: [
        CommonModule,
        RouterModule,
    ],
    exports: [NDDTabComponent, NDDTabsbarComponent],
    declarations: [NDDTabComponent, NDDTabsbarComponent],
})
export class NDDTabsbarModule { }
