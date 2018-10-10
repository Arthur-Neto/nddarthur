import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';

import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';
import { ProductGridService } from '../shared/product-grid.service';
import { ProductService } from '../shared/product.service';
import { ProductDeleteCommand } from '../shared/model/product.model';

@Component({
  templateUrl: './product-list.component.html',
})
export class ProductListComponent extends GridUtilsComponent implements OnInit {

  constructor(private gridService: ProductGridService,
    private productService: ProductService,
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
    this.router.navigate(['./create'],
      { relativeTo: this.route });
  }

  public deleteProduct(evento: SelectionEvent): void {
    this.gridService.loading = true;
    const productsToDelete: ProductDeleteCommand = new ProductDeleteCommand(this.getSelectedEntities());
    this.productService.delete(productsToDelete)
      .take(1)
      .do(() => this.gridService.loading = false)
      .subscribe(() => {
        this.gridService.query(this.createFormattedState());
        this.selectedRows = [];
      });
  }

  public redirectOpenProduct(): void {
    this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`],
      { relativeTo: this.route });
  }
}
