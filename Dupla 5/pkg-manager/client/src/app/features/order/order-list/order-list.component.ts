import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';

import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';
import { OrderGridService } from '../shared/order-grid.service';
import { OrderService } from '../shared/order.service';
import { OrderDeleteCommand } from '../shared/model/order.model';

@Component({
  templateUrl: './order-list.component.html',
})
export class OrderListComponent extends GridUtilsComponent {

  constructor(private gridService: OrderGridService,
    private orderService: OrderService,
    private router: Router,
    private route: ActivatedRoute) {
    super();
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

  public deleteOrder(evento: SelectionEvent): void {
    this.gridService.loading = true;
    const ordersToDelete: OrderDeleteCommand = new OrderDeleteCommand(this.getSelectedEntities());
    this.orderService.delete(ordersToDelete)
      .take(1)
      .do(() => this.gridService.loading = false)
      .subscribe(() => {
        this.gridService.query(this.createFormattedState());
        this.selectedRows = [];
      });

  }

  public redirectOpenOrder(): void {
    this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`],
      { relativeTo: this.route });
  }
}
