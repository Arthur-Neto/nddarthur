import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';

import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';
import { TransportadorGridService } from '../shared/transportador-grid.service';
import { TransportadorService } from '../shared/transportador.service';
import { TransportadorExcluirComando } from '../shared/model/transportador.model';

@Component({
  templateUrl: './transportador-list.component.html',
})
export class TransportadorListComponent extends GridUtilsComponent implements OnInit {

  constructor(private gridService: TransportadorGridService,
    private transportadorService: TransportadorService,
    private router: Router,
    private route: ActivatedRoute) {
    super();
    this.gridService.query(this.createFormattedState());
  }

  public ngOnInit(): void {
    this.gridService.query(this.createFormattedState());
  }

  public onDataStateChange(state: DataStateChangeEvent): void {
    this.state = state;
    this.gridService.query(this.createFormattedState());
    this.selectedRows = [];
  }

  public onSelectionChange(evento: SelectionEvent): void {
    this.updateSelectedRows(evento.selectedRows, true);
    this.updateSelectedRows(evento.deselectedRows, false);
  }

  public onClick(): void {
    this.router.navigate(['./criar'],
      { relativeTo: this.route });
  }

  public deleteTransportador(evento: SelectionEvent): void {
    this.gridService.loading = true;
    const transportadorsToExcluir: TransportadorExcluirComando = new TransportadorExcluirComando(this.getSelectedEntities());
    this.transportadorService.delete(transportadorsToExcluir)
      .take(1)
      .do(() => this.gridService.loading = false)
      .subscribe(() => {
        this.gridService.query(this.createFormattedState());
        this.selectedRows = [];
      });
  }

  public redirectOpenTransportador(): void {
    this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`],
      { relativeTo: this.route });
  }
}
