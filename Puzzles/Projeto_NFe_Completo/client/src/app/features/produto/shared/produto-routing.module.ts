import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { ProdutoListComponent } from '../produto-list/produto-list.component';
import { ProdutoResolveService } from './produto.service';
import { ProdutoViewComponent } from '../produto-view/produto-view.component';
import { ProdutoDetalheComponent } from '../produto-detalhe/produto-detalhe.component';
import { ProdutoAdicionarComponent } from '../produto-adicionar/produto-adicionar.component';
import { ProdutoEditarComponent } from '../produto-editar/produto-editar.component';

const rotasProduto: Routes = [
    {
        path: '',
        children: [
            {
                path: '',
                component: ProdutoListComponent,
            },
            {
                path: 'adicionar',
                component: ProdutoAdicionarComponent,
                data: {
                    breadcrumbOptions: {
                        breadcrumbId: 'adicionar',
                    },
                },
            },
        ],
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
            {
                path: '',
                component: ProdutoViewComponent,
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
                                component: ProdutoDetalheComponent,
                            },
                            {
                                path: 'edit',
                                component: ProdutoEditarComponent,
                            },
                        ],
                    },
                ],
            },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(rotasProduto)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class ProdutoRoutingModule {
}
