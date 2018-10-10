import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DestinatarioListaComponent } from './destinatario-lista/destinatario-lista.component';
const rotasDestinatario: Routes = [
    {
        path: '',
        component: DestinatarioListaComponent,
    },
];
@NgModule({
    imports:[RouterModule.forChild(rotasDestinatario)],
    exports:[RouterModule],
    providers: [],
})
export class DestinatarioRoutingModule {

}
