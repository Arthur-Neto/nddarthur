import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { DatePickerModule } from '@progress/kendo-angular-dateinputs';

import { SharedModule } from '../../../shared/shared.module';
import { NotaFiscalRoutingModule } from './notaFiscal-routing.module';
import { NDDTabsbarModule } from '../../../shared/ndd-ng-tabsbar/component';
import { NDDTitlebarModule } from '../../../shared/ndd-ng-titlebar/component';
import { NotaFiscalSharedModule } from './notaFiscal-shared.module';

import { NotaFiscalResolveService } from './notaFiscal.service';
import { NotaFiscalGridService } from './notaFiscal-grid.service';
import { NotaFiscalListComponent } from '../notaFiscal-list/notaFiscal-list.component';

@NgModule({
    imports: [
        SharedModule,
        GridModule,
        DatePickerModule,
        NotaFiscalRoutingModule,
        NotaFiscalSharedModule,
        NDDTabsbarModule,
        NDDTitlebarModule,
    ],
    exports: [],
    declarations: [
        NotaFiscalListComponent,
    ],
    providers: [
        NotaFiscalGridService,
        NotaFiscalResolveService,
    ],
})
export class NotaFiscalModule {
}
