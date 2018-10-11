import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subject } from 'rxjs/Subject';

import { Destinatario } from '../shared/model/destinatario.model';
import { DestinatarioResolveService } from '../shared/destinatario.service';

@Component({
    templateUrl: './destinatario-detalhe.component.html',
})
export class DestinatarioDetalheComponent implements OnInit, OnDestroy {

    public destinatario: Destinatario;

    public isLoading: boolean;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: DestinatarioResolveService,
        private router: Router,
        private route: ActivatedRoute) { }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .do(() => this.isLoading = false)
            .subscribe((destinatario: Destinatario) => {
                this.destinatario = Object.assign(new Destinatario(), destinatario);
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
