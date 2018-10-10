import { Component, OnInit, OnDestroy } from '@angular/core';

import { Product } from '../shared/model/product.model';
import { Subject } from 'rxjs/Subject';
import { ProductResolveService } from '../shared/product.service';

@Component({
    templateUrl: './product-view.component.html',
})
export class ProductViewComponent implements OnInit, OnDestroy {
    public title: string;

    public infoItems: object[];

    private product: Product;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: ProductResolveService) { }

    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((product: Product) => {
                this.product = product;
                this.createProperty();
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public createProperty(): void {
        this.title = this.product.name;
        const availableDescription: string = this.product.isAvailable ? 'Disponível' : 'Indisponível';
        const expDescription: string = 'Expira em: ' + new Date(this.product.expiration).toLocaleDateString();
        const manufactureDescription: string = 'Fabricado em: ' + new Date(this.product.manufacture).toLocaleDateString();

        this.infoItems = [
            {
                value: expDescription,
                description: expDescription,
            },
            {
                value: manufactureDescription,
                description: manufactureDescription,
            },
            {
                value: availableDescription,
                description: availableDescription,
            },
        ];
    }
}
