import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { DatePickerModule } from '@progress/kendo-angular-dateinputs';

import { SharedModule } from '../../../shared/shared.module';
import { DestinatarioRoutingModule } from './destinatario-routing.module';
import { NDDTabsbarModule } from '../../../shared/ndd-ng-tabsbar/component';
import { NDDTitlebarModule } from '../../../shared/ndd-ng-titlebar/component';
import { DestinatarioSharedModule } from './destinatario-shared.module';
import { EnderecoModule } from '../../endereco/endereco.module';

import { DestinatarioResolveService } from './destinatario.service';
import { DestinatarioGridService } from './destinatario-grid.service';
import { DestinatarioAdicionarComponent } from '../destinatario-adicionar/destinatario-adicionar.component';
import { DestinatarioListComponent } from '../destinatario-list/destinatario-list.component';
import { DestinatarioViewComponent } from '../destinatario-view/destinatario-view.component';
import { DestinatarioDetalheComponent } from '../destinatario-detalhe/destinatario-detalhe.component';
import { DestinatarioEditComponent } from '../destinatario-edit/destinatario-edit.component';
import { DestinatarioFormComponent } from '../destinatario-form/destinatario-form.component';

@NgModule({
    imports: [
        SharedModule,
        GridModule,
        DatePickerModule,
        DestinatarioRoutingModule,
        DestinatarioSharedModule,
        NDDTabsbarModule,
        NDDTitlebarModule,
        EnderecoModule,
    ],
    exports: [],
    declarations: [
        DestinatarioAdicionarComponent,
        DestinatarioListComponent,
        DestinatarioViewComponent,
        DestinatarioDetalheComponent,
        DestinatarioEditComponent,
        DestinatarioFormComponent,
    ],
    providers: [
        DestinatarioGridService,
        DestinatarioResolveService,
    ],
})
export class DestinatarioModule {
}
