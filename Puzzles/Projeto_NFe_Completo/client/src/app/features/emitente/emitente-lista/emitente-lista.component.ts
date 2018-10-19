// A import { EmitenteService } from './../shared/emitente.service';
import { EmitenteGridService } from './../shared/emitente-grid.service';
import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { GridUtilsComponent } from './../../../shared/grid-utils/grid-utils-component';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';

@Component({
    templateUrl: './emitente-lista.component.html',
})

export class EmitenteListaComponent extends GridUtilsComponent {

    constructor(private gridService: EmitenteGridService,
        // A private emitenteService: EmitenteService,
        private router: Router,
        private route: ActivatedRoute) {
        super();
        this.gridService.query(this.createFormattedState());
    }
    public dataStateChange(state: DataStateChangeEvent): void {
        this.state = state;
        this.gridService.query(state);
        this.selectedRows = [];
    }

    public onSelectionChange(event: SelectionEvent): void {
        this.updateSelectedRows(event.selectedRows, true);
        this.updateSelectedRows(event.deselectedRows, false);
    }

    public adicionarEmitente(): void {
        this.router.navigate(['./adicionar'], {relativeTo: this.route });
    }

    public abrirEmitente(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`], {relativeTo: this.route });
    }
}
