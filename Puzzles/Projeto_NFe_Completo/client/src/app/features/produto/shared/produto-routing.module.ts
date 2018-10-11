import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { ProdutoListComponent } from '../produto-list/produto-list.component';
import { ProdutoResolveService } from './produto.service';

const produtoRoutes: Routes = [
    {
        path: '',
        component: ProdutoListComponent,
    },
    {
        path: ':produtoId',
        resolve: {
            product: ProdutoResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbId: 'produto',
            },
        },
        children: [
            {},
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(produtoRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class ProdutoRoutingModule {
}
