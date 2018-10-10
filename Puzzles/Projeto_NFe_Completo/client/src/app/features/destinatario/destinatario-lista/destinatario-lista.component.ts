import { Component } from '@angular/core';
import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';
import { DestinatarioServicoGrid } from '../shared/destinatario.servico';

@Component({
    templateUrl: './destinatario-lista.component.html',
})
export class DestinatarioListaComponent extends GridUtilsComponent{

    constructor(private gridService: DestinatarioServicoGrid) {
        super();
        this.gridService.query(this.createFormattedState());
    }
}
