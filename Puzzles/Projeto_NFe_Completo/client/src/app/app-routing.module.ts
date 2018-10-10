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
                redirectTo: 'destinatarios',
                pathMatch: 'full',
            },
            {
                path: 'destinatarios',
                loadChildren: './features/destinatario/shared/destinatario.module#DestinatarioModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Destinatarios',
                    },
                },
            },
            {
                path: 'transportadores',
                loadChildren: './features/transportador/shared/transportador.module#TransportadorModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Transportadores',
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
