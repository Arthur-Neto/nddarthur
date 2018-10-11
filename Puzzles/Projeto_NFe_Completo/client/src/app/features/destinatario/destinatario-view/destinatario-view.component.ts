import { Component, OnInit, OnDestroy } from '@angular/core';

import { Subject } from 'rxjs/Subject';

import { Destinatario } from '../shared/model/destinatario.model';
import { DestinatarioResolveService } from '../shared/destinatario.service';

@Component({
    templateUrl: './destinatario-view.component.html',
})
export class DestinatarioViewComponent implements OnInit, OnDestroy {
    public title: string;

    public infoItems: object[];

    private destinatario: Destinatario;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: DestinatarioResolveService) { }

    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((destinatario: Destinatario) => {
                this.destinatario = destinatario;
                this.createProperty();
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public createProperty(): void {
        this.title = this.destinatario.nomeRazaoSocial;
        const inscricaoEstadualDescricao: string = 'Inscrição estadual: ' + this.destinatario.inscricaoEstadual;

        this.infoItems = [
            {
                value: inscricaoEstadualDescricao,
                description: inscricaoEstadualDescricao,
            },
        ];
    }
}
