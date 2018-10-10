import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { TransportadorListComponent } from '../transportador-list/transportador-list.component';
import { TransportadorResolveService } from './transportador.service';

const transportadorRoutes: Routes = [
    {
        path: '',
        component: TransportadorListComponent,
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
            {},
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
