import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GridComponent } from '@progress/kendo-angular-grid';
import { Component, Input, Output, EventEmitter, OnInit, ViewChild, Renderer2, OnDestroy } from '@angular/core';

import { ProdutoNotaGridService } from './../../shared/produtos-grid.service';
import { ProdutoService } from './../../../produto/shared/produto.service';
import { Produto } from '../../../../features/produto/shared/model/produto.model';

const matches: any = (el: any, selector: any): any => (el.matches || el.msMatchesSelector).call(el, selector);

@Component({
    selector: 'ndd-nota-produtos-form',
    templateUrl: './notaFiscal-produtos-form.component.html',
})

export class NotaFiscalProdutosFormComponent implements OnInit, OnDestroy {
    @Input() public formModel: FormGroup;

    @Output() public submit: EventEmitter<any> = new EventEmitter<any>();

    public produtosAdicionados: Produto[] = [];

    public data: Produto[];

    public produtos: Produto[];

    public produtoSelecionado: Produto;

    @ViewChild(GridComponent)
    private grid: GridComponent;
    private editedRowIndex: number;
    private docClickSubscription: any;
    private isNew: boolean;

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private produtoService: ProdutoService,
        private formBuilder: FormBuilder,
        private produtoGridService: ProdutoNotaGridService,
        private renderer: Renderer2) { }

    public ngOnInit(): void {
        this.docClickSubscription = this.renderer.listen('document', 'click', this.onDocumentClick.bind(this));
        this.produtoService.getAll()
        .subscribe((produtos: Produto[]) => {
            this.produtos = produtos;
            this.data = this.produtos.slice();
        });
    }

    public ngOnDestroy(): void {
        this.docClickSubscription();
    }

    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }

    public onSubmit(event: any): void {
        event.stopPropagation();
        this.submit.emit(this.formModel);
    }

    public encontrarErro(controlGroup: string, controlName: string): boolean {
        return this.formModel.get(controlGroup).get(controlName).hasError('required')
            && this.formModel.get(controlGroup).get(controlName).touched;
    }

    public onFilter(value: any): void {
        this.data = this.produtos.filter((s: any) => s.name.toLowerCase().indexOf(value.toLowerCase()) !== -1);
    }

    public onSelect(produto: Produto): void {
        this.produtoSelecionado = produto;
    }

    public addProduto(produto: Produto): void {
        this.closeEditor();

        this.formModel = this.criarFormGroup({
            id: this.produtoSelecionado.id,
            descricao: this.produtoSelecionado.descricao,
            valor: this.produtoSelecionado.valor,
            codigo: this.produtoSelecionado.codigo,
            quantidade: 0,
            aliquotaICMS: this.produtoSelecionado.aliquotaICMS,
            aliquotaIPI: this.produtoSelecionado.aliquotaIPI,

        });
        this.isNew = true;

        this.produtosAdicionados.push(this.produtoSelecionado);
    }

    public criarFormGroup(produto: Produto): FormGroup {
        return this.formBuilder.group({
            id: produto.id,
            codigo: [produto.codigo, Validators.required],
            valor: [produto.valor, Validators.required],
            descricao: [produto.descricao, Validators.required],
            aliquotaIPI: [produto.aliquotaIPI, Validators.required],
            aliquotaICMS: [produto.aliquotaICMS, Validators.required],
            quantidade: [produto.quantidade, Validators.required],
        });
    }

    public cellClickHandler({ isEdited, dataItem, rowIndex }: any): void {
        if (isEdited || (this.formModel && !this.formModel.valid)) {
            return;
        }
        this.saveCurrent();

        this.formModel = this.criarFormGroup(dataItem);
        this.editedRowIndex = rowIndex;

        this.grid.editRow(rowIndex, this.formModel);
    }

    private closeEditor(): void {
        this.grid.closeRow(this.editedRowIndex);

        this.isNew = false;
        this.editedRowIndex = undefined;
    }

    private saveCurrent(): void {
        if (this.formModel) {
            this.produtoGridService.save(this.formModel.value, this.isNew);
            this.closeEditor();
        }
    }

    private onDocumentClick(e: any): void {
        if (this.formModel && this.formModel.valid &&
            !matches(e.target, '#productsGrid tbody *, #productsGrid .k-grid-toolbar .k-button')) {
            this.saveCurrent();
        }
    }
}
