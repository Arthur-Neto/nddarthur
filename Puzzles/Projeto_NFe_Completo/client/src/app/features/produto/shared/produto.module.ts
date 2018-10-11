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
    ],
    providers: [
        ProdutoGridService,
        ProdutoResolveService,
    ],
})
export class ProdutoModule {
}
