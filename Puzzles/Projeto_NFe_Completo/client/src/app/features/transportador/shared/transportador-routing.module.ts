import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { TransportadorListComponent } from '../transportador-list/transportador-list.component';
import { TransportadorResolveService } from './transportador.service';
import { TransportadorDetalheComponent } from '../transportador-detalhe/transportador-detalhe.component';
import { TransportadorViewComponent } from '../transportador-view/transportador-view.component';
import { TransportadorAdicionarComponent } from '../transportador-adicionar/transportador-adicionar.component';
import { TransportadorEditarComponent } from '../transportador-editar/transportador-editar.component';

const transportadorRoutes: Routes = [
    {
        path: '',
        redirectTo: '',
        children: [
            {
                path: '',
                component: TransportadorListComponent,
            },
        ],
    },
    {
        path: 'adicionar',
        children: [
            {
                path: '',
                component: TransportadorAdicionarComponent,
            },
        ],
    },
    {
        path: ':transportadorId',
        resolve: {
            product: TransportadorResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbId: 'transportador',
            },
        },
        children: [
            {
                path: '',
                component: TransportadorViewComponent,
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
                                component: TransportadorDetalheComponent,
                            },
                            {
                                path: 'edit',
                                component: TransportadorEditarComponent,
                            },
                        ],
                    },
                ],
            },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(transportadorRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class TransportadorRoutingModule {
}
