import { EnderecoDetalhesComponent } from './../../endereco/endereco-detalhes/endereco-detalhes.component';
import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { DatePickerModule } from '@progress/kendo-angular-dateinputs';

import { SharedModule } from '../../../shared/shared.module';
import { DestinatarioRoutingModule } from './destinatario-routing.module';
import { NDDTabsbarModule } from '../../../shared/ndd-ng-tabsbar/component';
import { NDDTitlebarModule } from '../../../shared/ndd-ng-titlebar/component';
import { DestinatarioSharedModule } from './destinatario-shared.module';

import { DestinatarioResolveService } from './destinatario.service';
import { DestinatarioGridService } from './destinatario-grid.service';
import { DestinatarioCriarComponent } from '../destinatario-criar/destinatario-criar.component';
import { DestinatarioListComponent } from '../destinatario-list/destinatario-list.component';
import { DestinatarioViewComponent } from '../destinatario-view/destinatario-view.component';
import { DestinatarioDetalheComponent } from '../destinatario-detalhe/destinatario-detalhe.component';
import { DestinatarioEditComponent } from '../destinatario-edit/destinatario-edit.component';

@NgModule({
    imports: [
        SharedModule,
        GridModule,
        DatePickerModule,
        DestinatarioRoutingModule,
        DestinatarioSharedModule,
        NDDTabsbarModule,
        NDDTitlebarModule,
    ],
    exports: [],
    declarations: [
        DestinatarioCriarComponent,
        DestinatarioListComponent,
        DestinatarioViewComponent,
        DestinatarioDetalheComponent,
        DestinatarioEditComponent,
        EnderecoDetalhesComponent,
    ],
    providers: [
        DestinatarioGridService,
        DestinatarioResolveService,
    ],
})
export class DestinatarioModule {
}
