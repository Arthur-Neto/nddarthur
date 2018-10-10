import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LayoutComponent } from './core/layout/layout.component';

const appRoutes: Routes = [
    {
        path: 'page-not-found',
        loadChildren: './features/error-pages/page-not-found/page-not-found.module#PageNotFoundModule',
    },
    {
        path: '',
        component: LayoutComponent,
        children: [
            {
                path: '',
                redirectTo: 'produtos',
                pathMatch: 'full',
            },
            {
                path: 'produtos',
                loadChildren: './features/product/shared/product.module#ProductModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Produtos',
                    },
                },
            },
            {
                path: 'pedidos',
                loadChildren: './features/order/shared/order.module#OrderModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Pedidos',
                    },
                },
            },
        ],
    },
    { path: '**', redirectTo: 'page-not-found', pathMatch: 'full' },
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes, {
        paramsInheritanceStrategy: 'always',
    })],
    exports: [RouterModule],
})
export class AppRoutingModule { }
