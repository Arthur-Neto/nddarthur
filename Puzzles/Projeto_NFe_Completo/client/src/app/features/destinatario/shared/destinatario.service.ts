import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { Observable } from 'rxjs/Observable';

import { BaseService } from '../../../core/utils';
import { CORE_CONFIG_TOKEN, ICoreConfig } from '../../../core/core.config';
import { DestinatarioExcluirComando, Destinatario, DestinatarioEditComando, DestinatarioCriarComando } from './model/destinatario.model';
import { AbstractResolveService } from '../../../core/utils/abstract-resolve.service';
import { NDDBreadcrumbService } from '../../../shared/ndd-ng-breadcrumb';

@Injectable()
export class DestinatarioService extends BaseService {

    public api: string;

    constructor(public httpClient: HttpClient,
        @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig) {
        super(httpClient);
        this.api = `${config.apiEndpoint}api/destinatario`;
    }

    public delete(cmd: DestinatarioExcluirComando): Observable<boolean> {
        return super.deleteRequestWithBody(this.api, cmd);
    }

    public get(id: number): Observable<Destinatario> {
        return this.http.get(`${this.api}/${id}`).map((response: Destinatario) => {

            return response;
        });
    }

    public getAll(): Observable<Destinatario[]> {
        return this.http.get(this.api).map((response: any) => response.items);
    }

    public put(cmd: DestinatarioEditComando): Observable<boolean> {
        return this.http.put(this.api, cmd).map((response: boolean) => response);
    }

    public post(cmd: DestinatarioCriarComando): Observable<boolean> {
        return this.http.post(this.api, cmd).map((response: boolean) => response);
    }
}

@Injectable()
export class DestinatarioResolveService extends AbstractResolveService<Destinatario> {
    constructor(private destinatarioService: DestinatarioService,
        private breadcrumbService: NDDBreadcrumbService,
        router: Router) {
        super(router);
        this.paramsProperty = 'destinatarioId';
    }

    protected loadEntity(destinatarioId: number): Observable<Destinatario> {
        return this.destinatarioService
            .get(destinatarioId)
            .take(1)
            .do((destinatario: Destinatario) => {
                this.breadcrumbService.setMetadata({
                    id: 'destinatario',
                    label: destinatario.nomeRazaoSocial,
                    sizeLimit: true,
                });
            });
    }
}
