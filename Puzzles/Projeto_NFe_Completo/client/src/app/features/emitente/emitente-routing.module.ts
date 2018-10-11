import { EmitenteDetalhesComponent } from './emitente-view/emitente-detalhes/emitente-detalhes.component';
import { EmitenteViewComponent } from './emitente-view/emitente-view.component';
import { EmitenteResolveService } from './shared/emitente-resolver.service';
import { EmitenteAdicionarComponent } from './emitente-view/emitente-adicionar/emitente-adicionar.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmitenteListaComponent } from './../emitente/emitente-lista/emitente-lista.component';
import { EmitenteEditarComponent } from './../emitente/emitente-view/emitente-editar/emitente-editar.component';

const rotasEmitente: Routes = [
    {
        path: '',
        children: [
            {
                path: '',
                component: EmitenteListaComponent,
            },
            {
                path: 'adicionar',
                component: EmitenteAdicionarComponent,
                data: {
                    breadcrumbOptions: {
                        breadcrumbId: 'adicionar',
                    },
                },
            },
        ],
    },
    {
        path: ':emitenteId',
        resolve: {
            product: EmitenteResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbId: 'emitente',
            },
        },
        children: [
            {
                path: '',
                component: EmitenteViewComponent,
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
                                component: EmitenteDetalhesComponent,
                            },
                            {
                                path: 'editar',
                                component: EmitenteEditarComponent,
                            },
                        ],
                    },
                ],
            },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(rotasEmitente)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})

export class EmitenteRoutingModule {

}
