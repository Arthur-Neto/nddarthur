import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';

import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';
import { ProdutoGridService } from '../shared/produto-grid.service';
import { ProdutoService } from '../shared/produto.service';
import { ProdutoExcluirComando } from '../shared/model/produto.model';

@Component({
  templateUrl: './produto-list.component.html',
})
export class ProdutoListComponent extends GridUtilsComponent implements OnInit {

  constructor(private gridService: ProdutoGridService,
    private produtoService: ProdutoService,
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

  public novoProduto(): void {
    this.router.navigate(['./adicionar'],
      { relativeTo: this.route });
  }

  public deletarProduto(evento: SelectionEvent): void {
    this.gridService.loading = true;
    const produtosAExcluir: ProdutoExcluirComando = new ProdutoExcluirComando(this.getSelectedEntities());
    this.produtoService.delete(produtosAExcluir)
      .take(1)
      .do(() => this.gridService.loading = false)
      .subscribe(() => {
        this.gridService.query(this.createFormattedState());
        this.selectedRows = [];
      });
  }

  public abrirProduto(): void {
    this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`],
      { relativeTo: this.route });
  }
}
