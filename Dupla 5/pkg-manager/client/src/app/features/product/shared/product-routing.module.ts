import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { ProductListComponent } from '../product-list/product-list.component';
import { ProductCreateComponent } from '../product-create/product-create.component';
import { ProductResolveService } from './product.service';
import { ProductViewComponent } from '../product-view/product-view.component';
import { ProductDetailComponent } from '../product-detail/product-detail.component';
import { ProductEditComponent } from '../product-edit/product-edit.component';

const productRoutes: Routes = [
    {
        path: '',
        component: ProductListComponent,
    },
    {
        path: 'create',
        children: [
            {
                path: '',
                component: ProductCreateComponent,
            },
        ],
    },
    {
        path: ':productId',
        resolve: {
            product: ProductResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbId: 'product',
            },
        },
        children: [
            {
                path: '',
                component: ProductViewComponent,
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
                                component: ProductDetailComponent,
                            },
                            {
                                path: 'edit',
                                component: ProductEditComponent,
                            },
                        ],
                    },
                ],
            },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(productRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class ProductRoutingModule {
}
