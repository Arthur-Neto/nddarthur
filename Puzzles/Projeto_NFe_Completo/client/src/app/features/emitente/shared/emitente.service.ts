import { Observable } from 'rxjs/Observable';
import { Emitente } from './emitente.model';
import { BaseService } from './../../../core/utils/base-service';
import { HttpClient } from '@angular/common/http';
import { CORE_CONFIG_TOKEN, ICoreConfig } from './../../../core/core.config';
import { Injectable, Inject } from '@angular/core';

@Injectable()

export class EmitenteService extends BaseService  {

    private api: string;

    // A private tableName: string = 'Emitentes';

    constructor( @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig, public http: HttpClient) {
        super(http);
        this.api = `${config.apiEndpoint}api/emitente`;
    }

    public get(id: number): Observable<Emitente> {
        return this.http.get(`${this.api}/${id}`).map((response: Emitente) => {
            return response;
        });
    }
}
