import { Injectable } from '@angular/core';

import { ProdutoService } from './../../produto/shared/produto.service';
import { Produto } from '../../produto/shared/model/produto.model';

@Injectable()
export class ProdutoNotaGridService {
    private data: any[];
    private counter: number;

    constructor(produtoService: ProdutoService) {
        produtoService.getAll().subscribe((produtos: Produto[]) => {
            this.data = produtos;
            this.counter = this.data.length;
        });
    }

    public produtos(): any[] {
        return this.data;
    }

    public remove(produto: any): void {
        const index: any = this.data.findIndex(({ id }: any) => id === produto.id);
        this.data.splice(index, 1);
    }

    public save(produto: any, isNew: boolean): void {
        console.log(produto);
        console.log(this.data);

        if (isNew) {
            produto.id = this.counter++;
            this.data.splice(0, 0, produto);
        } else {
            Object.assign(
                this.data.find(({ id }: any) => id === produto.id), produto,
            );
        }
    }
}
