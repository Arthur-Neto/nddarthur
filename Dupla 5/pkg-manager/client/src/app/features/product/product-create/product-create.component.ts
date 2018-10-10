import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { Product, ProductCreateCommand } from '../shared/model/product.model';
import { Subject } from 'rxjs/Subject';
import { ProductService } from '../shared/product.service';
import { ProductValidators } from '../shared/product-validator';

@Component({
    templateUrl: './product-create.component.html',
})
export class ProductCreateComponent implements OnInit, OnDestroy {

    public formModel: FormGroup;

    public product: Product;

    public isLoading: boolean;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private service: ProductService,
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
        this.isLoading = false;
    }

    public onSubmit(event: Event): void {
        event.stopPropagation();
        const cmd: ProductCreateCommand = new ProductCreateCommand(this.formModel.value);
        this.service.post(cmd).subscribe(() => {
            this.router.navigate(['produtos']);
        });
    }

    public redirect(event: Event): void {
        this.router.navigate(['produtos']);
    }
}
