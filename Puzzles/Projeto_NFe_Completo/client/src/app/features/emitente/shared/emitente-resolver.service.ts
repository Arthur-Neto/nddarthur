import { EmitenteService } from './emitente.service';
import { Emitente } from './emitente.model';
import { NDDBreadcrumbService } from './../../../shared/ndd-ng-breadcrumb/component/ndd-ng-breadcrumb.service';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { AbstractResolveService } from './../../../core/utils/abstract-resolve.service';

@Injectable()
export class EmitenteResolveService extends AbstractResolveService<Emitente> {
    constructor(private service: EmitenteService, private breadcrumbService: NDDBreadcrumbService, router: Router) {
        super(router);
        this.paramsProperty = 'emitenteId';
    }
    protected loadEntity(emitenteId: number): Observable<Emitente> {
        return this.service
        .get(emitenteId)
        .take(1)
        .do((emitente: Emitente) => {
            this.breadcrumbService.setMetadata({
                id: 'emitente',
                label: emitente.nomeRazaoSocial,
                sizeLimit: true,
            });
        });
    }
}
