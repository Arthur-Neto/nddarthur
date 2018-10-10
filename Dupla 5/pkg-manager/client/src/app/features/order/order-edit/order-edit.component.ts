import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { Order, OrderEditCommand } from '../shared/model/order.model';
import { Product } from './../../product/shared/model/product.model';
import { Subject } from 'rxjs/Subject';
import { OrderResolveService, OrderService } from '../shared/order.service';
import { ProductService } from '../../product/shared/product.service';

@Component({
    templateUrl: './order-edit.component.html',
})
export class OrderEditComponent implements OnInit, OnDestroy {

    public products: Product[];

    public formModel: FormGroup;

    public data: Product[];

    public order: Order;

    public selectedProduct: {name: string};

    public isLoading: boolean;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: OrderResolveService,
        private service: OrderService,
        private fb: FormBuilder,
        private productService: ProductService,
        private router: Router) { }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.formModel = this.fb.group({
            id: [''],
            customer: ['', Validators.required],
            quantity: ['', Validators.required],
            productName: ['', Validators.required],
            total: ['', Validators.required],
            productId: ['', Validators.required],
        });
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .do(() => this.isLoading = false)
            .subscribe((order: Order) => {
                this.order = Object.assign(new Order(), order);
                this.formModel.patchValue(this.order);
                this.selectedProduct = { name: this.order.productName };
        });
        this.productService.getAll().subscribe((products: Product[]) => {
            this.products = products;
            this.data = this.products.slice();
        });

    }

    public onFilter(value: any): void {
        this.data = this.products.filter((s: any) => s.name.toLowerCase().indexOf(value.toLowerCase()) !== -1);
    }

    public onSubmit(event: Event): void {
        event.stopPropagation();
        const cmd: OrderEditCommand = new OrderEditCommand(this.formModel.value);
        this.service.put(cmd).subscribe(() => {
            this.router.navigate(['pedidos']);
        });
    }

    public onSelect(product: Product): void {
        this.formModel.patchValue({productId: product.id, productName: product.name});
    }

    public redirect(event: Event): void {
        this.router.navigate(['pedidos']);
    }
}
