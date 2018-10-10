import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { OrderListComponent } from '../order-list/order-list.component';
import { OrderCreateComponent } from '../order-create/order-create.component';
import { OrderResolveService } from './order.service';
import { OrderViewComponent } from '../order-view/order-view.component';
import { OrderDetailComponent } from '../order-detail/order-detail.component';
import { OrderEditComponent } from '../order-edit/order-edit.component';

const orderRoutes: Routes = [
    {
        path: '',
        component: OrderListComponent,
    },
    {
        path: 'create',
        children: [
            {
                path: '',
                component: OrderCreateComponent,
            },
        ],
    },
    {
        path: ':orderId',
        resolve: {
            order: OrderResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbId: 'order',
            },
        },
        children: [
            {
                path: '',
                component: OrderViewComponent,
                children: [
                    {
                        path: '',
                        redirectTo: 'info',
                        pathMatch: 'full',
                    },
                    {
                        path: 'info',
                        children: [
                            {
                                path: '',
                                component: OrderDetailComponent,
                            },
                            {
                                path: 'edit',
                                component: OrderEditComponent,
                            },
                        ],
                    },
                ],
            },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(orderRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class OrderRoutingModule {
}
