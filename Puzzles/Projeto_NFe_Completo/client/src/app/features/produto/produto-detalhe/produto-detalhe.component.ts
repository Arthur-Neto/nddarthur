import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subject } from 'rxjs/Subject';

import { Produto } from '../shared/model/produto.model';
import { ProdutoResolveService } from '../shared/produto.service';

@Component({
    templateUrl: './produto-detalhe.component.html',
})
export class ProdutoDetalheComponent implements OnInit, OnDestroy {

    public produto: Produto;

    public IPI: number;
    public ICMS: number;

    public isLoading: boolean;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: ProdutoResolveService,
        private router: Router,
        private route: ActivatedRoute) { }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .do(() => this.isLoading = false)
            .subscribe((produto: Produto) => {
                this.produto = Object.assign(new Produto(), produto);
                this.IPI = produto.aliquotaIPI * produto.valor;
                this.ICMS = produto.aliquotaICMS * produto.valor;
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
