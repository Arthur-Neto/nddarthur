import { Component, Input } from '@angular/core';
import { Endereco } from '../shared/model/endereco.model';

@Component({
    selector: 'ndd-endereco-detalhes',
    templateUrl: './endereco-detalhes.component.html',
})

export class EnderecoDetalhesComponent {
    @Input() public endereco: Endereco;
}
