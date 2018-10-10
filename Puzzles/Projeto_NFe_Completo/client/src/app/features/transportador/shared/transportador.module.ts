import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { DatePickerModule } from '@progress/kendo-angular-dateinputs';

import { SharedModule } from '../../../shared/shared.module';
import { TransportadorRoutingModule } from './transportador-routing.module';
import { NDDTabsbarModule } from '../../../shared/ndd-ng-tabsbar/component';
import { NDDTitlebarModule } from '../../../shared/ndd-ng-titlebar/component';
import { TransportadorSharedModule } from './transportador-shared.module';

import { TransportadorResolveService } from './transportador.service';
import { TransportadorGridService } from './transportador-grid.service';
import { TransportadorListComponent } from '../transportador-list/transportador-list.component';

@NgModule({
    imports: [
        SharedModule,
        GridModule,
        DatePickerModule,
        TransportadorRoutingModule,
        TransportadorSharedModule,
        NDDTabsbarModule,
        NDDTitlebarModule,
    ],
    exports: [],
    declarations: [
        TransportadorListComponent,
    ],
    providers: [
        TransportadorGridService,
        TransportadorResolveService,
    ],
})
export class TransportadorModule {
}
