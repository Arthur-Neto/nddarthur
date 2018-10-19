import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subject } from 'rxjs/Subject';

import { Transportador } from '../shared/model/transportador.model';
import { TransportadorResolveService } from '../shared/transportador.service';
import { Endereco } from '../../endereco/shared/model/endereco.model';

@Component({
    templateUrl: './transportador-detalhe.component.html',
})
export class TransportadorDetalheComponent implements OnInit, OnDestroy {

    public transportador: Transportador;

    public endereco: Endereco;

    public responsabilidadeFrete: string;

    public isLoading: boolean;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: TransportadorResolveService,
        private router: Router,
        private route: ActivatedRoute) { }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .do(() => this.isLoading = false)
            .subscribe((transportador: Transportador) => {
                // tslint:disable-next-line:no-console
        console.log('transportadorId em detalhe: ' + transportador.id);

                this.transportador = Object.assign(new Transportador(), transportador);
                this.endereco = Object.assign(new Endereco(), transportador.endereco);
                this.responsabilidadeFrete = transportador.responsabilidadeFrete ? 'Sim' : 'Não';
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public onEdit(): void {
        this.router.navigate(['./edit'],
            { relativeTo: this.route });
    }

    public redirect(): void {
        this.router.navigate(['']);
    }

}
