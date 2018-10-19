import { EmitenteResolveService } from './../shared/emitente-resolver.service';
import { Subject } from 'rxjs/Subject';
import { Emitente } from './../shared/emitente.model';
import { Component, OnInit, OnDestroy } from '@angular/core';

@Component({
    templateUrl: './emitente-view.component.html',
})

export class EmitenteViewComponent implements OnInit, OnDestroy {
    public emitente: Emitente;
    public titulo: string;

    public infoItems: object[];

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: EmitenteResolveService) {
    }

    public ngOnInit(): void {
        this.resolver.onChanges
        .takeUntil(this.ngUnsubscribe)
            .subscribe((emitente: Emitente) => {
                this.emitente = emitente;
                this.createProperty();
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    private createProperty(): void {
        this.titulo = this.emitente.nomeFantasia;

        const inscricaoEstadualDescricao: string = 'CNPJ: ' + this.emitente.cnpj.numero;

        this.infoItems = [
            {
                value: inscricaoEstadualDescricao,
                description: inscricaoEstadualDescricao,
            },
        ];
    }
}
