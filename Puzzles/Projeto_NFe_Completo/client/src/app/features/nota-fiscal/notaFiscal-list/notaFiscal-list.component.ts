import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';

import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';
import { NotaFiscalGridService } from '../shared/notaFiscal-grid.service';
import { NotaFiscalService } from '../shared/notaFiscal.service';
import { NotaFiscalExcluirComando } from '../shared/model/notaFiscal.model';

@Component({
  templateUrl: './notaFiscal-list.component.html',
})
export class NotaFiscalListComponent extends GridUtilsComponent implements OnInit {

  constructor(private gridService: NotaFiscalGridService,
    private notaFiscalService: NotaFiscalService,
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

  public deleteNotaFiscal(evento: SelectionEvent): void {
    this.gridService.loading = true;
    const notaFiscalsToExcluir: NotaFiscalExcluirComando = new NotaFiscalExcluirComando(this.getSelectedEntities());
    this.notaFiscalService.delete(notaFiscalsToExcluir)
      .take(1)
      .do(() => this.gridService.loading = false)
      .subscribe(() => {
        this.gridService.query(this.createFormattedState());
        this.selectedRows = [];
      });
  }

  public redirectOpenNotaFiscal(): void {
    this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`],
      { relativeTo: this.route });
  }
}
