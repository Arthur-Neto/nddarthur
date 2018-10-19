import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Destinatario, DestinatarioAdicionarComando } from '../shared/model/destinatario.model';
import { DestinatarioService } from '../shared/destinatario.service';
import { Endereco } from '../../endereco/shared/model/endereco.model';
import { Documento } from './../../../shared/models/documento/documento.model';
import { TipoDocumento } from './../../../shared/models/documento/documento.enum';

@Component({
    templateUrl: './destinatario-adicionar.component.html',
})
export class DestinatarioAdicionarComponent implements OnInit {

    public isLoading: boolean;

    public titulo: string = 'Adicionar Destinatário';

    public destinatario: Destinatario;

    public formModelDestinatarioPessoaFisica: FormGroup = this.fb.group(
        {
            nomeRazaoSocial: ['', Validators.required],
            cpf: ['', Validators.required],
        },
    );

    public formModelDestinatarioPessoaJuridica: FormGroup = this.fb.group(
        {
            nomeRazaoSocial: ['', Validators.required],
            inscricaoEstadual: ['', Validators.required],
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

    public formModel: FormGroup = this.fb.group({
        tipoPessoa: ['1', Validators.required],
    });

    constructor(private service: DestinatarioService,
        private fb: FormBuilder,
        private router: Router) { }

    public ngOnInit(): void {
        this.isLoading = false;
        this.formModel.addControl('endereco', this.formModelEndereco);
        this.formModel.addControl('pessoaFisica', this.formModelDestinatarioPessoaFisica);

        this.formModel.controls.tipoPessoa.valueChanges.subscribe((value: number) => {
            this.alterarFormPessoa(value.toString());
        });
    }

    public onSubmit(event: Event): void {
        this.isLoading = true;
        event.stopPropagation();
        const cmd: DestinatarioAdicionarComando = new DestinatarioAdicionarComando(this.formModel.value);
        this.service.post(cmd).subscribe(() => {
            this.isLoading = false;
            this.router.navigate(['destinatarios']);
        });
    }

    public redirect(event: Event): void {
        this.router.navigate(['destinatarios']);
    }

    public adicionarDestinatario(): void {
        this.isLoading = true;

        let destinatario: Destinatario;

        let documento: Documento;

        if (this.formModel.value.tipoPessoa === '1') {
            destinatario = this.formModel.value.pessoaFisica;
            documento = new Documento(this.formModel.value.pessoaFisica.cpf, TipoDocumento.CPF);
        } else {
            destinatario = this.formModel.value.pessoaJuridica;
            documento = new Documento(this.formModel.value.pessoaJuridica.cnpj, TipoDocumento.CNPJ);
        }

        const endereco: Endereco = this.formModel.value.endereco;

        destinatario.documento = documento;
        destinatario.endereco = endereco;

        const destinatarioAdicionarComando: DestinatarioAdicionarComando = new DestinatarioAdicionarComando(destinatario);

        // tslint:disable-next-line:no-console
        console.log(destinatarioAdicionarComando);

        this.service.post(destinatarioAdicionarComando)
            .take(1)
            .do(() => this.isLoading = false)
            .subscribe(() => {
                this.router.navigate(['destinatarios']);
            });
    }

    private alterarFormPessoa(key: string): void {
        switch (key.toString()) {

            case '1':
                this.formModel.removeControl('pessoaJuridica');
                this.formModel.addControl('pessoaFisica', this.formModelDestinatarioPessoaFisica);
                break;
            case '2':
                this.formModel.removeControl('pessoaFisica');
                this.formModel.addControl('pessoaJuridica', this.formModelDestinatarioPessoaJuridica);
                break;

            default:
                break;
        }
    }
}
