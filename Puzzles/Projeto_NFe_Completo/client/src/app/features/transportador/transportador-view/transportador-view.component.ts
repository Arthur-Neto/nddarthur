import { Component, OnInit, OnDestroy } from '@angular/core';

import { Subject } from 'rxjs/Subject';

import { Transportador } from '../shared/model/transportador.model';
import { TransportadorResolveService } from '../shared/transportador.service';

@Component({
    templateUrl: './transportador-view.component.html',
})
export class TransportadorViewComponent implements OnInit, OnDestroy {
    public title: string;

    public infoItems: object[];

    private transportador: Transportador;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: TransportadorResolveService) { }

    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((transportador: Transportador) => {
                this.transportador = transportador;

                // tslint:disable-next-line:no-console
                console.log('transportadorId em view: ' + transportador.id);

                this.createProperty();
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public createProperty(): void {
        this.title = this.transportador.nomeRazaoSocial;
        const documentoDescricao: string = 'Documento: ' + this.transportador.documento.numero;

        this.infoItems = [
            {
                value: documentoDescricao,
                description: documentoDescricao,
            },
        ];
    }
}
