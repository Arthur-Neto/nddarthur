import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { NotaFiscalListComponent } from '../notaFiscal-list/notaFiscal-list.component';
import { NotaFiscalViewComponent } from '../notaFiscal-view/notaFiscal-view.component';

import { NotaFiscalResolveService } from './notaFiscal.service';
import { NotaFiscalDetalheComponent } from '../notaFiscal-view/notaFiscal-detalhe/notaFiscal-detalhe.component';
import { NotaFiscalAdicionarComponent } from '../notaFiscal-adicionar/notaFiscal-adicionar.component';

const notaFiscalRoutes: Routes = [
    {
        path: '',
        children: [
            {
                path: '',
                component: NotaFiscalListComponent,
            },
            {
                path: 'adicionar',
                component: NotaFiscalAdicionarComponent,
                data: {
                    breadcrumbOptions: {
                        breadcrumbId: 'adicionar',
                    },
                },
            },
        ],
    },
    {
        path: ':notaFiscalId',
        resolve: {
            notaFiscal: NotaFiscalResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbId: 'notaFiscal',
            },
        },
        children: [
            {
                path: '',
                component: NotaFiscalViewComponent,
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
                                component: NotaFiscalDetalheComponent,
                            },
                        ],
                    },
                ],
            },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(notaFiscalRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class NotaFiscalRoutingModule {
}
