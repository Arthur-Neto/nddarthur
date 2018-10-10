import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Order } from '../shared/model/order.model';
import { Subject } from 'rxjs/Subject';
import { OrderResolveService } from '../shared/order.service';

@Component({
    templateUrl: './order-detail.component.html',
})
export class OrderDetailComponent implements OnInit, OnDestroy {

    public order: Order;

    public isLoading: boolean;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: OrderResolveService,
        private router: Router,
        private route: ActivatedRoute) { }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .do(() => this.isLoading = false)
            .subscribe((order: Order) => {
                this.order = Object.assign(new Order(), order);
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public onEdit(): void {
        this.router.navigate(['./edit'],
            { relativeTo: this.route });
    }

    public redirect(): void {
        this.router.navigate(['']);
    }

}
