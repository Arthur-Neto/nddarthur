import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subject } from 'rxjs/Subject';

import { NotaFiscal } from '../../shared/model/notaFiscal.model';
import { Produto } from 'src/app/features/produto/shared/model/produto.model';
import { NotaFiscalResolveService } from '../../shared/notaFiscal.service';

@Component({
    templateUrl: './notaFiscal-detalhe.component.html',
})
export class NotaFiscalDetalheComponent implements OnInit, OnDestroy {

    public notaFiscal: NotaFiscal;

    public produtos: Produto[];

    public isLoading: boolean;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: NotaFiscalResolveService,
        private router: Router,
        private route: ActivatedRoute) { }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .do(() => this.isLoading = false)
            .subscribe((notaFiscal: NotaFiscal) => {
                this.notaFiscal = Object.assign(new NotaFiscal(), notaFiscal);
                this.produtos = Object.assign(new Array(), notaFiscal.produtos);
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
