import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { NotaFiscalListComponent } from '../notaFiscal-list/notaFiscal-list.component';
import { NotaFiscalResolveService } from './notaFiscal.service';

const notaFiscalRoutes: Routes = [
    {
        path: '',
        component: NotaFiscalListComponent,
    },
    {
        path: ':notaFiscalId',
        resolve: {
            product: NotaFiscalResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbId: 'notaFiscal',
            },
        },
        children: [
            {},
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
