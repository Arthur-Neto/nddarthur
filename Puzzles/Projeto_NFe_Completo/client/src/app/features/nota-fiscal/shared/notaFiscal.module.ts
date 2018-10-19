import { ProdutoSharedModule } from './../../produto/shared/produto-shared.module';
import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { DatePickerModule } from '@progress/kendo-angular-dateinputs';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

import { SharedModule } from '../../../shared/shared.module';
import { NotaFiscalRoutingModule } from './notaFiscal-routing.module';
import { NDDTabsbarModule } from '../../../shared/ndd-ng-tabsbar/component';
import { NDDTitlebarModule } from '../../../shared/ndd-ng-titlebar/component';
import { NotaFiscalSharedModule } from './notaFiscal-shared.module';
import { DestinatarioSharedModule } from '../../destinatario/shared/destinatario-shared.module';
import { EmitenteSharedModule } from '../../emitente/shared/emitente-shared.module';
import { TransportadorSharedModule } from '../../transportador/shared/transportador-shared.module';

import { NotaFiscalResolveService } from './notaFiscal.service';
import { NotaFiscalGridService } from './notaFiscal-grid.service';

import { NotaFiscalListComponent } from '../notaFiscal-list/notaFiscal-list.component';
import { NotaFiscalViewComponent } from '../notaFiscal-view/notaFiscal-view.component';
import { NotaFiscalDetalheComponent } from '../notaFiscal-view/notaFiscal-detalhe/notaFiscal-detalhe.component';
import { NotaFiscalAdicionarComponent } from '../notaFiscal-adicionar/notaFiscal-adicionar.component';
import { NotaFiscalProdutosFormComponent } from '../notaFiscal-form/notaFiscal-produtos/notaFiscal-produtos-form.component';
import { NotaFiscalFormComponent } from '../notaFiscal-form/notaFiscal-form.component';
import { ProdutoNotaGridService } from './produtos-grid.service';

@NgModule({
    imports: [
        SharedModule,
        GridModule,
        DatePickerModule,
        NotaFiscalRoutingModule,
        NotaFiscalSharedModule,
        NDDTabsbarModule,
        NDDTitlebarModule,
        DropDownsModule,
        DestinatarioSharedModule,
        TransportadorSharedModule,
        EmitenteSharedModule,
        ProdutoSharedModule,
    ],
    exports: [],
    declarations: [
        NotaFiscalListComponent,
        NotaFiscalViewComponent,
        NotaFiscalDetalheComponent,
        NotaFiscalAdicionarComponent,
        NotaFiscalProdutosFormComponent,
        NotaFiscalFormComponent,
    ],
    providers: [
        NotaFiscalGridService,
        NotaFiscalResolveService,
        ProdutoNotaGridService,
    ],
})
export class NotaFiscalModule {
}
