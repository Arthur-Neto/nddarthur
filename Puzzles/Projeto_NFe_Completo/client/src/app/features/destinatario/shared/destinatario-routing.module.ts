import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { DestinatarioListComponent } from '../destinatario-list/destinatario-list.component';
import { DestinatarioResolveService } from './destinatario.service';
import { DestinatarioCriarComponent } from '../destinatario-criar/destinatario-criar.component';
import { DestinatarioViewComponent } from '../destinatario-view/destinatario-view.component';
import { DestinatarioDetalheComponent } from '../destinatario-detalhe/destinatario-detalhe.component';
import { DestinatarioEditComponent } from '../destinatario-edit/destinatario-edit.component';

const destinatarioRoutes: Routes = [
    {
        path: '',
        component: DestinatarioListComponent,
    },
    {
        path: 'criar',
        children: [
            {
                path: '',
                component: DestinatarioCriarComponent,
            },
        ],
    },
    {
        path: ':destinatarioId',
        resolve: {
            product: DestinatarioResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbId: 'destinatario',
            },
        },
        children: [
            {
                path: '',
                component: DestinatarioViewComponent,
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
                                component: DestinatarioDetalheComponent,
                            },
                            {
                                path: 'edit',
                                component: DestinatarioEditComponent,
                            },
                        ],
                    },
                ],
            },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(destinatarioRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class DestinatarioRoutingModule {
}
