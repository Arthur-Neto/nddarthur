import { EnderecoDetalhesComponent } from './endereco-detalhes/endereco-detalhes.component';
import { SharedModule } from './../../shared/shared.module';
import { EnderecoFormComponent } from './endereco-form/endereco-form.component';
import { NgModule } from '@angular/core';

@NgModule({
    imports: [
        SharedModule,
    ],
    exports: [
        EnderecoFormComponent,
        EnderecoDetalhesComponent,
    ],
    declarations: [
        EnderecoFormComponent,
        EnderecoDetalhesComponent,
    ],
    providers: [
    ],
})

export class EnderecoModule {

}
