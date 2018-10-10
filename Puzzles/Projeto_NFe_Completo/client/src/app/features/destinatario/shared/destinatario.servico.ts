import { CORE_CONFIG, ICoreConfig } from './../../../core/core.config';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Injectable, Inject } from '@angular/core';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { State, toODataString } from '@progress/kendo-data-query';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class DestinatarioServicoGrid extends BehaviorSubject<GridDataResult> {
    public loading: boolean;

    constructor(private httpClient: HttpClient,
        @Inject(CORE_CONFIG) private config: ICoreConfig) {
        super(null);
    }

    public query(state: State): void {
        this.fetch(state).subscribe((result: GridDataResult) => super.next(result));
    }

    protected fetch(state: any): Observable<GridDataResult> {
        const queryStr: string = `${toODataString(state)}&$count=true`;
        this.loading = true;

        return this.httpClient.
            get(`${this.config.apiEndpoint}api/destinatario?${queryStr}`)
            .map((response: any): GridDataResult => ({
                data: response.items,
                total: parseInt(response.count, 10),
            })).do(() => this.loading = false);
    }
}
