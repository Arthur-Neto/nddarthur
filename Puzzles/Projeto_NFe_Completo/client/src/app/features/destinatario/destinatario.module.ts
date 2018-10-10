import { NgModule } from '@angular/core';
import { DestinatarioListaComponent } from './destinatario-lista/destinatario-lista.component';
import { DestinatarioRoutingModule } from './destinatario-routing.module';
import { DestinatarioServicoGrid } from './shared/destinatario.servico';
import { GridModule } from '@progress/kendo-angular-grid';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
    imports: [
        DestinatarioRoutingModule,
        SharedModule,
        GridModule,
    ],
    declarations: [
        DestinatarioListaComponent,
    ],
    exports: [],
    providers: [
        DestinatarioServicoGrid,
    ],
})
export class DestinatarioModule {
}
