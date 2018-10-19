import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { DatePickerModule } from '@progress/kendo-angular-dateinputs';

import { SharedModule } from '../../../shared/shared.module';
import { ProdutoRoutingModule } from './produto-routing.module';
import { NDDTabsbarModule } from '../../../shared/ndd-ng-tabsbar/component';
import { NDDTitlebarModule } from '../../../shared/ndd-ng-titlebar/component';
import { ProdutoSharedModule } from './produto-shared.module';

import { ProdutoResolveService } from './produto.service';
import { ProdutoGridService } from './produto-grid.service';
import { ProdutoListComponent } from '../produto-list/produto-list.component';
import { ProdutoViewComponent } from '../produto-view/produto-view.component';
import { ProdutoDetalheComponent } from '../produto-detalhe/produto-detalhe.component';
import { ProdutoAdicionarComponent } from '../produto-adicionar/produto-adicionar.component';
import { ProdutoEditarComponent } from '../produto-editar/produto-editar.component';
import { ProdutoFormComponent } from '../produto-form/produto-form.component';

@NgModule({
    imports: [
        SharedModule,
        GridModule,
        DatePickerModule,
        ProdutoRoutingModule,
        ProdutoSharedModule,
        NDDTabsbarModule,
        NDDTitlebarModule,
    ],
    exports: [],
    declarations: [
        ProdutoListComponent,
        ProdutoViewComponent,
        ProdutoDetalheComponent,
        ProdutoAdicionarComponent,
        ProdutoEditarComponent,
        ProdutoFormComponent,
    ],
    providers: [
        ProdutoGridService,
        ProdutoResolveService,
    ],
})
export class ProdutoModule {
}
