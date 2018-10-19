import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProdutoService } from './../shared/produto.service';
import { Produto, ProdutoCriarComando } from './../shared/model/produto.model';
import { Router } from '@angular/router';

@Component({
    templateUrl: './produto-adicionar.component.html',
})

export class ProdutoAdicionarComponent {

    public isLoading: boolean = false;

    public formModel: FormGroup = this.fb.group(
        {
            codigo: ['', Validators.required],
            descricao: ['', Validators.required],
            valor: ['', Validators.required],
        },
    );

    constructor(
        private fb: FormBuilder,
        private service: ProdutoService,
        private router: Router,
    ) { }

    public adicionarProduto(formModel: FormGroup): void {
        this.isLoading = true;

        const produto: Produto = formModel.value;

        const produtoCriarComando: ProdutoCriarComando = new ProdutoCriarComando(produto);

        this.service.post(produtoCriarComando)
            .take(1)
            .do(() => this.isLoading = false)
            .subscribe(() => {
                this.router.navigate(['produtos']);
            });
    }

    public redirect(event: Event): void {
        this.router.navigate(['produtos']);
    }

}
