import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { BaseService } from '../../../core/utils';
import { CORE_CONFIG_TOKEN, ICoreConfig } from '../../../core/core.config';
import { ProductDeleteCommand, Product, ProductEditCommand, ProductCreateCommand } from './model/product.model';
import { Observable } from 'rxjs/Observable';
import { AbstractResolveService } from '../../../core/utils/abstract-resolve.service';
import { NDDBreadcrumbService } from '../../../shared/ndd-ng-breadcrumb';

@Injectable()
export class ProductService extends BaseService {

    public api: string;

    constructor(public httpClient: HttpClient,
        @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig) {
        super(httpClient);
        this.api = `${config.apiEndpoint}api/products`;
    }

    public delete(cmd: ProductDeleteCommand): Observable<boolean> {
        return super.deleteRequestWithBody(this.api, cmd);
    }

    public get(id: number): Observable<Product> {
        return this.http.get(`${this.api}/${id}`).map((response: Product) => {
            response.manufacture = new Date(response.manufacture);
            response.expiration = new Date(response.expiration);

            return response;
        });
    }

    public getAll(): Observable<Product[]> {
        return this.http.get(this.api).map((response: any) => response.items);
    }

    public put(cmd: ProductEditCommand): Observable<boolean> {
        return this.http.put(this.api, cmd).map((response: boolean) => response);
    }

    public post(cmd: ProductCreateCommand): Observable<boolean> {
        return this.http.post(this.api, cmd).map((response: boolean) => response);
    }
}

@Injectable()
export class ProductResolveService extends AbstractResolveService<Product> {
    constructor(private productService: ProductService,
        private breadcrumbService: NDDBreadcrumbService,
        router: Router) {
        super(router);
        this.paramsProperty = 'productId';
    }

    protected loadEntity(productId: number): Observable<Product> {
        return this.productService
            .get(productId)
            .take(1)
            .do((product: Product) => {
                this.breadcrumbService.setMetadata({
                    id: 'product',
                    label: product.name,
                    sizeLimit: true,
                });
            });
    }
}
