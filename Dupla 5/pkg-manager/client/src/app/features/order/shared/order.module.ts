import { ProductSharedModule } from './../../product/shared/product-shared.module';
import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { DatePickerModule } from '@progress/kendo-angular-dateinputs';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { SharedModule } from '../../../shared/shared.module';
import { OrderRoutingModule } from './order-routing.module';
import { NDDTabsbarModule } from '../../../shared/ndd-ng-tabsbar/component';
import { NDDTitlebarModule } from '../../../shared/ndd-ng-titlebar/component';

import { OrderService, OrderResolveService } from './order.service';
import { OrderGridService } from './order-grid.service';

import { OrderListComponent } from '../order-list/order-list.component';
import { OrderCreateComponent } from '../order-create/order-create.component';
import { OrderViewComponent } from '../order-view/order-view.component';
import { OrderDetailComponent } from '../order-detail/order-detail.component';
import { OrderEditComponent } from '../order-edit/order-edit.component';

@NgModule({
    imports: [
        SharedModule,
        GridModule,
        DatePickerModule,
        DropDownsModule,
        OrderRoutingModule,
        ProductSharedModule,
        NDDTabsbarModule,
        NDDTitlebarModule,
    ],
    exports: [],
    declarations: [
        OrderListComponent,
        OrderCreateComponent,
        OrderViewComponent,
        OrderDetailComponent,
        OrderEditComponent,
    ],
    providers: [
        OrderService,
        OrderGridService,
        OrderResolveService,
    ],
})

export class OrderModule {
}
