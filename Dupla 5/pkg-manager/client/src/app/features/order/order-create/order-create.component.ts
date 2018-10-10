import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { OrderCreateCommand } from '../shared/model/order.model';
import { Subject } from 'rxjs/Subject';
import { OrderService } from '../shared/order.service';
import { ProductService } from '../../product/shared/product.service';
import { Product } from '../../product/shared/model/product.model';

@Component({
    templateUrl: './order-create.component.html',
})
export class OrderCreateComponent implements OnInit, OnDestroy {

    public formModel: FormGroup;

    public products: Product[];

    public selectedProduct: {};

    public data: Product[];

    public isLoading: boolean;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private service: OrderService,
        private productService: ProductService,
        private fb: FormBuilder,
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
            productId: ['', Validators.required],
        });
        this.productService.getAll()
        .do(() => this.isLoading = false)
        .subscribe((products: Product[]) => {
            this.products = products;
            this.data = this.products.slice();
            this.selectedProduct = { name: 'selecione um produto' };
        });
    }

    public onFilter(value: any): void {
        this.data = this.products.filter((s: any) => s.name.toLowerCase().indexOf(value.toLowerCase()) !== -1);
    }

    public onSelect(product: Product): void {
        this.formModel.patchValue({productId: product.id});
    }

    public onSubmit(event: Event): void {
        event.stopPropagation();
        const cmd: OrderCreateCommand = new OrderCreateCommand(this.formModel.value);
        this.service.post(cmd).subscribe(() => {
            this.router.navigate(['pedidos']);
        });
    }

    public redirect(event: Event): void {
        this.router.navigate(['pedidos']);
    }
}
