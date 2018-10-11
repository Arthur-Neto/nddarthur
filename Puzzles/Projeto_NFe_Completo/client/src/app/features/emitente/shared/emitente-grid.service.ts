import { HttpClient } from '@angular/common/http';
import { ICoreConfig, CORE_CONFIG_TOKEN } from './../../../core/core.config';
import { Observable } from 'rxjs/Observable';
import { toODataString, State } from '@progress/kendo-data-query';
import { Injectable, Inject } from '@angular/core';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()

export class EmitenteGridService extends BehaviorSubject<GridDataResult>{
    public loading: boolean;

    constructor(private httpCliente: HttpClient,
        @Inject(CORE_CONFIG_TOKEN) private config: ICoreConfig) {
        super(null);
    }

    public query(state: State): void {
        this.fetch(state).subscribe((result: GridDataResult) => super.next(result));
    }

    protected fetch(state: any): Observable<GridDataResult> {
        const queryStr: string = `${toODataString(state)}&$count=true`;
        this.loading = true;

        return this.httpCliente
            .get(`${this.config.apiEndpoint}api/emitente?${queryStr}`)
            .map((response: any): GridDataResult => ({
                data: response.items,
                total: parseInt(response.count, 10),
            }))
            .do(() => this.loading = false);
    }
}
