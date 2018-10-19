import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { Observable } from 'rxjs/Observable';

import { BaseService } from '../../../core/utils';
import { CORE_CONFIG_TOKEN, ICoreConfig } from '../../../core/core.config';
import { TransportadorExcluirComando, Transportador, TransportadorEditarComando, TransportadorAdicionarComando } from './model/transportador.model';
import { AbstractResolveService } from '../../../core/utils/abstract-resolve.service';
import { NDDBreadcrumbService } from '../../../shared/ndd-ng-breadcrumb';

@Injectable()
export class TransportadorService extends BaseService {

    public api: string;

    constructor(public httpClient: HttpClient,
        @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig) {
        super(httpClient);
        this.api = `${config.apiEndpoint}api/transportador`;
    }

    public delete(cmd: TransportadorExcluirComando): Observable<boolean> {
        return super.deleteRequestWithBody(this.api, cmd);
    }

    public get(id: number): Observable<Transportador> {
        return this.http.get(`${this.api}/${id}`).map((response: Transportador) => {
// tslint:disable-next-line:no-console
console.log('transportadorId em service: ' + id);

return response;
        });
    }

    public getAll(): Observable<Transportador[]> {
        return this.http.get(this.api).map((response: any) => response.items);
    }

    public put(cmd: TransportadorEditarComando): Observable<boolean> {
        return this.http.put(this.api, cmd).map((response: boolean) => response);
    }

    public post(cmd: TransportadorAdicionarComando): Observable<boolean> {
        return this.http.post(this.api, cmd).map((response: boolean) => response);
    }
}

@Injectable()
export class TransportadorResolveService extends AbstractResolveService<Transportador> {
    constructor(private transportadorService: TransportadorService,
        private breadcrumbService: NDDBreadcrumbService,
        router: Router) {
        super(router);
        this.paramsProperty = 'transportadorId';
    }

    protected loadEntity(transportadorId: number): Observable<Transportador> {

        // tslint:disable-next-line:no-console
        console.log('transportadorId em resolveservice: ' + transportadorId);

        return this.transportadorService
            .get(transportadorId)
            .take(1)
            .do((transportador: Transportador) => {
                this.breadcrumbService.setMetadata({
                    id: 'transportador',
                    label: transportador.nomeRazaoSocial,
                    sizeLimit: true,
                });
            });
    }
}
