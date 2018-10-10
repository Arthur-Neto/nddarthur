import { SharedModule } from './../../shared/shared.module';
import { EnderecoFormComponent } from './endereco-form/endereco-form.component';
import { NgModule } from '@angular/core';

@NgModule({
    imports: [
        SharedModule,
    ],
    exports: [],
    declarations: [
        EnderecoFormComponent,
    ],
    providers: [
    ],
})

export class EnderecoModule {

}
