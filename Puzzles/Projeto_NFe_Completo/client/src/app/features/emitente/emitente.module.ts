import { EmitenteEditarComponent } from './emitente-view/emitente-editar/emitente-editar.component';
import { EmitenteAdicionarComponent } from './emitente-view/emitente-adicionar/emitente-adicionar.component';
import { EmitenteViewComponent } from './emitente-view/emitente-view.component';
import { EmitenteDetalhesComponent } from './emitente-view/emitente-detalhes/emitente-detalhes.component';
import { EnderecoFormComponent } from './../endereco/endereco-form/endereco-form.component';
import { EnderecoModule } from './../endereco/endereco.module';
import { EmitenteResolveService } from './shared/emitente-resolver.service';
import { EmitenteGridService } from './shared/emitente-grid.service';
import { EmitenteFormComponent } from './emitente-form/emitente-form.component';
import { EmitenteListaComponent } from './emitente-lista/emitente-lista.component';
import { NDDTabsbarModule } from './../../shared/ndd-ng-tabsbar/component/ndd-ng-tabsbar.module';
import { NDDTitlebarModule } from './../../shared/ndd-ng-titlebar/component/ndd-ng-titlebar.module';
import { GridModule } from '@progress/kendo-angular-grid';
import { NgModule } from '@angular/core';
import { SharedModule } from './../../shared/shared.module';
import { EmitenteRoutingModule } from './../emitente/emitente-routing.module';
import { TextMaskModule } from 'angular2-text-mask';

@NgModule({
    imports:[
        SharedModule,
        GridModule,
        NDDTitlebarModule,
        NDDTabsbarModule,
        EnderecoModule,
        EmitenteRoutingModule,
        TextMaskModule,
    ],
    exports:[],
    declarations:[
        EmitenteListaComponent,
        EmitenteDetalhesComponent,
        EmitenteViewComponent,
        EmitenteFormComponent,
        EmitenteAdicionarComponent,
        EmitenteEditarComponent,
    ],
    providers:[
        EmitenteGridService,
        EmitenteResolveService,
    ],
})

export class EmitenteModule {

}
