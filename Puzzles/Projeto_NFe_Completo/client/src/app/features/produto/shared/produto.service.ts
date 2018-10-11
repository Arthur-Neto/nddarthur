import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { Observable } from 'rxjs/Observable';

import { BaseService } from '../../../core/utils';
import { CORE_CONFIG_TOKEN, ICoreConfig } from '../../../core/core.config';
import { ProdutoExcluirComando, Produto, ProdutoEditComando, ProdutoCriarComando } from './model/produto.model';
import { AbstractResolveService } from '../../../core/utils/abstract-resolve.service';
import { NDDBreadcrumbService } from '../../../shared/ndd-ng-breadcrumb';

@Injectable()
export class ProdutoService extends BaseService {

    public api: string;

    constructor(public httpClient: HttpClient,
        @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig) {
        super(httpClient);
        this.api = `${config.apiEndpoint}api/produto`;
    }

    public delete(cmd: ProdutoExcluirComando): Observable<boolean> {
        return super.deleteRequestWithBody(this.api, cmd);
    }

    public get(id: number): Observable<Produto> {
        return this.http.get(`${this.api}/${id}`).map((response: Produto) => {

            return response;
        });
    }

    public getAll(): Observable<Produto[]> {
        return this.http.get(this.api).map((response: any) => response.items);
    }

    public put(cmd: ProdutoEditComando): Observable<boolean> {
        return this.http.put(this.api, cmd).map((response: boolean) => response);
    }

    public post(cmd: ProdutoCriarComando): Observable<boolean> {
        return this.http.post(this.api, cmd).map((response: boolean) => response);
    }
}

@Injectable()
export class ProdutoResolveService extends AbstractResolveService<Produto> {
    constructor(private produtoService: ProdutoService,
        private breadcrumbService: NDDBreadcrumbService,
        router: Router) {
        super(router);
        this.paramsProperty = 'produtoId';
    }

    protected loadEntity(produtoId: number): Observable<Produto> {
        return this.produtoService
            .get(produtoId)
            .take(1)
            .do((produto: Produto) => {
                this.breadcrumbService.setMetadata({
                    id: 'produto',
                    label: produto.codigo,
                    sizeLimit: true,
                });
            });
    }
}
