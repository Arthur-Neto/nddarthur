import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { EmitenteService } from '../../shared/emitente.service';
import { EmitenteAdicionarComando, Emitente } from '../../shared/emitente.model';
import { Endereco } from './../../../endereco/shared/model/endereco.model';
import { Documento } from './../../../../shared/models/documento/documento.model';
import { TipoDocumento } from './../../../../shared/models/documento/documento.enum';

@Component({
    templateUrl: './emitente-adicionar.component.html',
})

export class EmitenteAdicionarComponent implements OnInit {

    public isLoading: boolean = false;

    public titulo: string = 'Adicionar Emitente';

    public formModelEmitente: FormGroup = this.fb.group(
        {
            nomeFantasia: ['', Validators.required],
            razaoSocial: ['', Validators.required],
            inscricaoEstadual: ['', Validators.required],
            inscricaoMunicipal: ['', Validators.required],
            cnpj: ['', Validators.required],
        },
    );

    public formModelEndereco: FormGroup = this.fb.group(
        {
            logradouro: ['', Validators.required],
            numero: ['', Validators.required],
            bairro: ['', Validators.required],
            municipio: ['', Validators.required],
            estado: ['', Validators.required],
            pais: ['', Validators.required],
        },
    );

    public formModel: FormGroup = this.fb.group({});

    constructor(
        private fb: FormBuilder,
        private service: EmitenteService,
        private router: Router,
    ) { }

    public ngOnInit(): void {
        this.isLoading = false;
        this.formModel.addControl('emitente', this.formModelEmitente);
        this.formModel.addControl('endereco', this.formModelEndereco);
    }

    public adicionarEmitente(): void {
        this.isLoading = true;

        const emitente: Emitente = this.formModel.value.emitente;
        const endereco: Endereco = this.formModel.value.endereco;
        const cnpj: Documento = new Documento(this.formModel.value.emitente.cnpj, TipoDocumento.CNPJ);

        emitente.cnpj = cnpj;
        emitente.endereco = endereco;

        const emitenteAdicionarComando: EmitenteAdicionarComando = new EmitenteAdicionarComando(emitente);

        this.service.adicionar(emitenteAdicionarComando)
            .take(1)
            .do(() => this.isLoading = false)
            .subscribe(() => {
                this.router.navigate(['emitentes']);
            });
    }
}
