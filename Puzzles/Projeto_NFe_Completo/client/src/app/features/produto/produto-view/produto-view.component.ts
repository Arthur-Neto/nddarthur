import { Component, OnInit, OnDestroy } from '@angular/core';

import { Subject } from 'rxjs/Subject';

import { Produto } from '../shared/model/produto.model';
import { ProdutoResolveService } from '../shared/produto.service';

@Component({
    templateUrl: './produto-view.component.html',
})
export class ProdutoViewComponent implements OnInit, OnDestroy {
    public title: string;

    public infoItems: object[];

    private produto: Produto;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: ProdutoResolveService) { }

    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((produto: Produto) => {
                this.produto = produto;
                this.createProperty();
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public createProperty(): void {
        this.title = this.produto.descricao;
        const codigo: string = 'Código: ' + this.produto.codigo;

        this.infoItems = [
            {
                value: codigo,
                description: codigo,
            },
        ];
    }
}
