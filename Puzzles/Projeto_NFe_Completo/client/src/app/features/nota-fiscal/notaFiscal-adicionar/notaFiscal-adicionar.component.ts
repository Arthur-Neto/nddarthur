import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { NotaFiscalService } from '../shared/notaFiscal.service';
import { NotaFiscal, NotaFiscalAdicionarComando } from '../shared/model/notaFiscal.model';

@Component({
    templateUrl: './notaFiscal-adicionar.component.html',
})

export class NotaFiscalAdicionarComponent implements OnInit {

    public isLoading: boolean = false;

    public titulo: string = 'Criar Nota Fiscal';

    public formModelNotaFiscal: FormGroup = this.fb.group(
        {
            id: [''],
            transportadorId: ['', Validators.required],
            destinatarioId: ['', Validators.required],
            emitenteId: ['', Validators.required],
            naturezaOperacao: ['', Validators.required],
            dataEntrada: ['', Validators.required],
            dataEmissao: [''],
            valorTotalFrete: ['', Validators.required],
        },
    );

    public formModelProduto: FormGroup = this.fb.group(
        {
            produtos: [''],
        },
    );

    public formModel: FormGroup = this.fb.group({});

    constructor(
        private fb: FormBuilder,
        private service: NotaFiscalService,
        private router: Router,
    ) { }

    public ngOnInit(): void {
        this.isLoading = false;
        this.formModel.addControl('notaFiscal', this.formModelNotaFiscal);
        this.formModel.addControl('produtos', this.formModelProduto);
    }

    public adicionarNotaFiscal(): void {
        this.isLoading = true;

        const notaFiscal: NotaFiscal = this.formModel.value.notaFiscal;

        const notaFiscalAdicionarComando: NotaFiscalAdicionarComando = new NotaFiscalAdicionarComando(notaFiscal);

        this.service.adicionar(notaFiscalAdicionarComando)
            .take(1)
            .do(() => this.isLoading = false)
            .subscribe(() => {
                this.router.navigate(['notasFiscais']);
            });
    }
}
