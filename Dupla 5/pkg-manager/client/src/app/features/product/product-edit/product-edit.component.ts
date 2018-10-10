import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { Product, ProductEditCommand } from '../shared/model/product.model';
import { Subject } from 'rxjs/Subject';
import { ProductResolveService, ProductService } from '../shared/product.service';
import { ProductValidators } from '../shared/product-validator';

@Component({
    templateUrl: './product-edit.component.html',
})
export class ProductEditComponent implements OnInit, OnDestroy {

    public formModel: FormGroup;

    public product: Product;

    public isLoading: boolean;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: ProductResolveService,
        private service: ProductService,
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
            name: ['', Validators.required],
            isAvailable: [''],
            expense: ['', Validators.required],
            sale: ['', Validators.required],
            manufacture: ['', Validators.required],
            expiration: ['', Validators.required],
        }, { validator: ProductValidators.checkProductDates });
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .do(() => this.isLoading = false)
            .subscribe((product: Product) => {
                this.product = Object.assign(new Product(), product);
                this.formModel.patchValue(this.product);
            });
    }

    public onSubmit(event: Event): void {
        event.stopPropagation();
        const cmd: ProductEditCommand = new ProductEditCommand(this.formModel.value);
        this.service.put(cmd).subscribe(() => {
            this.router.navigate(['produtos']);
        });

    }

    public redirect(event: Event): void {
        this.router.navigate(['produtos']);
    }
}
