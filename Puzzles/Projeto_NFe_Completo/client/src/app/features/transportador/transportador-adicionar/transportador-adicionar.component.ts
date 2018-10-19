import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TransportadorAdicionarComando, Transportador } from '../shared/model/transportador.model';
import { TransportadorService } from '../shared/transportador.service';
import { Endereco } from '../../endereco/shared/model/endereco.model';
import { Documento } from './../../../shared/models/documento/documento.model';
import { TipoDocumento } from './../../../shared/models/documento/documento.enum';

@Component({
    templateUrl: './transportador-adicionar.component.html',
})
export class TransportadorAdicionarComponent implements OnInit {

    public isLoading: boolean;

    public titulo: string = 'Adicionar Transportador';

    public transportador: Transportador;

    public formModelTransportadorPessoaFisica: FormGroup = this.fb.group(
        {
            nomeRazaoSocial: ['', Validators.required],
            cpf: ['', Validators.required],
            responsabilidadeFrete: [''],
        },
    );

    public formModelTransportadorPessoaJuridica: FormGroup = this.fb.group(
        {
            nomeRazaoSocial: ['', Validators.required],
            inscricaoEstadual: ['', Validators.required],
            cnpj: ['', Validators.required],
            responsabilidadeFrete: [''],
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

    public formModel: FormGroup = this.fb.group({
        tipoPessoa: ['1', Validators.required],
    });

    constructor(private service: TransportadorService,
        private fb: FormBuilder,
        private router: Router) { }

    public ngOnInit(): void {
        this.isLoading = false;
        this.formModel.addControl('endereco', this.formModelEndereco);
        this.formModel.addControl('pessoaFisica', this.formModelTransportadorPessoaFisica);

        this.formModel.controls.tipoPessoa.valueChanges.subscribe((value: number) => {
            this.alterarFormPessoa(value.toString());
        });
    }

    public onSubmit(event: Event): void {
        this.isLoading = true;
        event.stopPropagation();
        const cmd: TransportadorAdicionarComando = new TransportadorAdicionarComando(this.formModel.value);
        this.service.post(cmd).subscribe(() => {
            this.isLoading = false;
            this.router.navigate(['transportadores']);
        });
    }

    public redirect(event: Event): void {
        this.router.navigate(['transportadores']);
    }

    public adicionarTransportador(): void {
        this.isLoading = true;

        let documento: Documento;

        if (this.formModel.value.tipoPessoa === '1') {
            this.transportador = this.formModel.value.pessoaFisica;
            documento = new Documento(this.formModel.value.pessoaFisica.cpf, TipoDocumento.CPF);
            this.transportador.responsabilidadeFrete = this.formModel.value.pessoaFisica.responsabilidadeFrete;
        } else {
            this.transportador = this.formModel.value.pessoaJuridica;
            documento = new Documento(this.formModel.value.pessoaJuridica.cnpj, TipoDocumento.CNPJ);
            this.transportador.responsabilidadeFrete = this.formModel.value.pessoaJuridica.responsabilidadeFrete;
        }

        const endereco: Endereco = this.formModel.value.endereco;

        this.transportador.documento = documento;
        this.transportador.endereco = endereco;

        const transportadorAdicionarComando: TransportadorAdicionarComando = new TransportadorAdicionarComando(this.transportador);

        // tslint:disable-next-line:no-console
        console.log(transportadorAdicionarComando);

        this.service.post(transportadorAdicionarComando)
            .take(1)
            .do(() => this.isLoading = false)
            .subscribe(() => {
                this.router.navigate(['transportadores']);
            });
    }

    private alterarFormPessoa(key: string): void {
        switch (key.toString()) {

            case '1':
                this.formModel.removeControl('pessoaJuridica');
                this.formModel.addControl('pessoaFisica', this.formModelTransportadorPessoaFisica);
                break;
            case '2':
                this.formModel.removeControl('pessoaFisica');
                this.formModel.addControl('pessoaJuridica', this.formModelTransportadorPessoaJuridica);
                break;

            default:
                break;
        }
    }
}
