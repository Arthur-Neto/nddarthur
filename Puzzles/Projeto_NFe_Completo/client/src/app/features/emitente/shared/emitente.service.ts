import { Observable } from 'rxjs/Observable';
import { Emitente, EmitenteAdicionarComando, EmitenteEditarComando } from './emitente.model';
import { BaseService } from './../../../core/utils/base-service';
import { HttpClient } from '@angular/common/http';
import { CORE_CONFIG_TOKEN, ICoreConfig } from './../../../core/core.config';
import { Injectable, Inject } from '@angular/core';

@Injectable()

export class EmitenteService extends BaseService  {

    private api: string;

    constructor( @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig, public http: HttpClient) {
        super(http);
        this.api = `${config.apiEndpoint}api/emitente`;
    }

    public get(id: number): Observable<Emitente> {
        return this.http.get(`${this.api}/${id}`).map((response: Emitente) => {
            return response;
        });
    }

    public adicionar(comando: EmitenteAdicionarComando): Observable<number> {
        return this.http.post(`${this.api}`, comando).map((idResultado: number) => idResultado);
    }

    public getAll(): Observable<Emitente[]> {
        return this.http.get(this.api).map((response: any) => response.items);
    }

    public put(cmd: EmitenteEditarComando): Observable<boolean> {
        return this.http.put(this.api, cmd).map((response: boolean) => response);
    }
}
