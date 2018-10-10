import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

import { BaseService } from '../../../core/utils';
import { CORE_CONFIG_TOKEN, ICoreConfig } from '../../../core/core.config';
import { OrderDeleteCommand, Order, OrderEditCommand, OrderCreateCommand } from './model/order.model';
import { Observable } from 'rxjs/Observable';
import { AbstractResolveService } from '../../../core/utils/abstract-resolve.service';
import { NDDBreadcrumbService } from '../../../shared/ndd-ng-breadcrumb';

@Injectable()
export class OrderService extends BaseService {

    public api: string;

    constructor(public httpClient: HttpClient,
        @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig) {
        super(httpClient);
        this.api = `${config.apiEndpoint}api/orders`;
    }

    public delete(cmd: OrderDeleteCommand): Observable<boolean> {
        return super.deleteRequestWithBody(this.api, cmd);
    }

    public get(id: number): Observable<Order> {
        return this.http.get(`${this.api}/${id}`).map((response: Order) => {
            return response;
        });
    }

    public put(cmd: OrderEditCommand): Observable<boolean> {
        return this.http.put(this.api, cmd).map((response: boolean) => response);
    }

    public post(cmd: OrderCreateCommand): Observable<boolean> {
        return this.http.post(this.api, cmd).map((response: boolean) => response);
    }
}

@Injectable()
export class OrderResolveService extends AbstractResolveService<Order> {
    constructor(private orderService: OrderService,
        private breadcrumbService: NDDBreadcrumbService,
        router: Router) {
        super(router);
        this.paramsProperty = 'orderId';
    }

    protected loadEntity(orderId: number): Observable<Order> {
        return this.orderService
            .get(orderId)
            .take(1)
            .do((order: Order) => {
                this.breadcrumbService.setMetadata({
                    id: 'order',
                    label: order.id.toString(),
                    sizeLimit: true,
                });
            });
    }
}
