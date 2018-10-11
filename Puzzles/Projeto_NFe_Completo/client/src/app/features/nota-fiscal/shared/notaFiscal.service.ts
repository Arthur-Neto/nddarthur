import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { Observable } from 'rxjs/Observable';

import { BaseService } from '../../../core/utils';
import { CORE_CONFIG_TOKEN, ICoreConfig } from '../../../core/core.config';
import { NotaFiscalExcluirComando, NotaFiscal, NotaFiscalEditComando, NotaFiscalCriarComando } from './model/notaFiscal.model';
import { AbstractResolveService } from '../../../core/utils/abstract-resolve.service';
import { NDDBreadcrumbService } from '../../../shared/ndd-ng-breadcrumb';

@Injectable()
export class NotaFiscalService extends BaseService {

    public api: string;

    constructor(public httpClient: HttpClient,
        @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig) {
        super(httpClient);
        this.api = `${config.apiEndpoint}api/notaFiscal`;
    }

    public delete(cmd: NotaFiscalExcluirComando): Observable<boolean> {
        return super.deleteRequestWithBody(this.api, cmd);
    }

    public get(id: number): Observable<NotaFiscal> {
        return this.http.get(`${this.api}/${id}`).map((response: NotaFiscal) => {

            return response;
        });
    }

    public getAll(): Observable<NotaFiscal[]> {
        return this.http.get(this.api).map((response: any) => response.items);
    }

    public put(cmd: NotaFiscalEditComando): Observable<boolean> {
        return this.http.put(this.api, cmd).map((response: boolean) => response);
    }

    public post(cmd: NotaFiscalCriarComando): Observable<boolean> {
        return this.http.post(this.api, cmd).map((response: boolean) => response);
    }
}

@Injectable()
export class NotaFiscalResolveService extends AbstractResolveService<NotaFiscal> {
    constructor(private notaFiscalService: NotaFiscalService,
        private breadcrumbService: NDDBreadcrumbService,
        router: Router) {
        super(router);
        this.paramsProperty = 'notaFiscalId';
    }

    protected loadEntity(notaFiscalId: number): Observable<NotaFiscal> {
        return this.notaFiscalService
            .get(notaFiscalId)
            .take(1)
            .do((notaFiscal: NotaFiscal) => {
                this.breadcrumbService.setMetadata({
                    id: 'notaFiscal',
                    label: notaFiscal.chaveAcesso,
                    sizeLimit: true,
                });
            });
    }
}
