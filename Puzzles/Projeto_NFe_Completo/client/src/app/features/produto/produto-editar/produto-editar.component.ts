import { Router } from '@angular/router';
import { Subject } from 'rxjs/Subject';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Produto, ProdutoEditComando } from '../shared/model/produto.model';
import { ProdutoResolveService, ProdutoService } from '../shared/produto.service';

@Component({
    templateUrl: './produto-editar.component.html',
})

export class ProdutoEditarComponent implements OnInit, OnDestroy {

    public produto: Produto;

    public isLoading: boolean;

    public formModel: FormGroup = this.fb.group(
        {
            id: [''],
            codigo: ['', Validators.required],
            descricao: ['', Validators.required],
            valor: ['', Validators.required],
        },
    );
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: ProdutoResolveService,
        private service: ProdutoService,
        private fb: FormBuilder,
        private router: Router) { }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .do(() => this.isLoading = false)
            .subscribe((produto: Produto) => {
                this.produto = Object.assign(new Produto(), produto);
                this.formModel.patchValue(this.produto);
            });
    }

    public onSubmit(event: Event): void {
        event.stopPropagation();
        const cmd: ProdutoEditComando = new ProdutoEditComando(this.formModel.value);
        this.service.put(cmd).subscribe(() => {
            this.router.navigate(['produtos']);
        });

    }

    public redirect(event: Event): void {
        this.router.navigate(['produtos']);
    }

    public editarProduto(formModel: FormGroup): void {
        this.isLoading = true;

        this.produto = this.formModel.value;

        this.produto.id = this.formModel.value.id;

        const produtoEditarComando: ProdutoEditComando = new ProdutoEditComando(this.produto);

        this.service.put(produtoEditarComando)
            .take(1)
            .do(() => this.isLoading = false)
            .subscribe(() => {
                this.router.navigate(['produtos']);
            });

    }
}
