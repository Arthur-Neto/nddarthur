import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';

import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';
import { DestinatarioGridService } from '../shared/destinatario-grid.service';
import { DestinatarioService } from '../shared/destinatario.service';
import { DestinatarioExcluirComando } from '../shared/model/destinatario.model';

@Component({
  templateUrl: './destinatario-list.component.html',
})
export class DestinatarioListComponent extends GridUtilsComponent implements OnInit {

  constructor(private gridService: DestinatarioGridService,
    private destinatarioService: DestinatarioService,
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
    this.router.navigate(['./adicionar'],
      { relativeTo: this.route });
  }

  public deleteDestinatario(evento: SelectionEvent): void {
    this.gridService.loading = true;
    const destinatariosToExcluir: DestinatarioExcluirComando = new DestinatarioExcluirComando(this.getSelectedEntities());
    this.destinatarioService.delete(destinatariosToExcluir)
      .take(1)
      .do(() => this.gridService.loading = false)
      .subscribe(() => {
        this.gridService.query(this.createFormattedState());
        this.selectedRows = [];
      });
  }

  public redirectOpenDestinatario(): void {
    this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`],
      { relativeTo: this.route });
  }
}
