import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid';

import { SharedModule } from '../../../shared/shared.module';
import { TransportadorRoutingModule } from './transportador-routing.module';
import { NDDTabsbarModule } from '../../../shared/ndd-ng-tabsbar/component';
import { NDDTitlebarModule } from '../../../shared/ndd-ng-titlebar/component';
import { TransportadorSharedModule } from './transportador-shared.module';
import { EnderecoModule } from '../../endereco/endereco.module';
import { UiSwitchModule } from 'angular2-ui-switch';

import { TransportadorResolveService } from './transportador.service';
import { TransportadorGridService } from './transportador-grid.service';
import { TransportadorListComponent } from '../transportador-list/transportador-list.component';
import { TransportadorDetalheComponent } from '../transportador-detalhe/transportador-detalhe.component';
import { TransportadorViewComponent } from '../transportador-view/transportador-view.component';
import { TransportadorFormComponent } from '../transportador-form/transportador-form.component';
import { TransportadorAdicionarComponent } from '../transportador-adicionar/transportador-adicionar.component';
import { TransportadorEditarComponent } from '../transportador-editar/transportador-editar.component';

@NgModule({
    imports: [
        SharedModule,
        GridModule,
        TransportadorRoutingModule,
        TransportadorSharedModule,
        NDDTabsbarModule,
        NDDTitlebarModule,
        EnderecoModule,
        UiSwitchModule,
    ],
    exports: [],
    declarations: [
        TransportadorListComponent,
        TransportadorDetalheComponent,
        TransportadorViewComponent,
        TransportadorAdicionarComponent,
        TransportadorEditarComponent,
        TransportadorFormComponent,
    ],
    providers: [
        TransportadorGridService,
        TransportadorResolveService,
    ],
})
export class TransportadorModule {
}
