import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Product } from '../shared/model/product.model';
import { Subject } from 'rxjs/Subject';
import { ProductResolveService } from '../shared/product.service';

@Component({
    templateUrl: './product-detail.component.html',
})
export class ProductDetailComponent implements OnInit, OnDestroy {

    public product: Product;

    public availabilityText: string = '';

    public productProfit: number = 0;

    public productValidateDate: string;

    public isLoading: boolean;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: ProductResolveService,
        private router: Router,
        private route: ActivatedRoute) { }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .do(() => this.isLoading = false)
            .subscribe((product: Product) => {
                this.product = Object.assign(new Product(), product);
                this.availabilityText = product.isAvailable ? 'Disponível' : 'Indisponível';
                this.productProfit = this.product.calculateProfit();
                this.productValidateDate = this.product.calculateRemaningDays();
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
