import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { Destinatario, DestinatarioEditarComando } from '../shared/model/destinatario.model';
import { Subject } from 'rxjs/Subject';
import { DestinatarioResolveService, DestinatarioService } from '../shared/destinatario.service';
import { Documento } from './../../../shared/models/documento/documento.model';
import { TipoDocumento } from './../../../shared/models/documento/documento.enum';
import { Endereco } from '../../endereco/shared/model/endereco.model';

@Component({
    templateUrl: './destinatario-edit.component.html',
})
export class DestinatarioEditComponent implements OnInit, OnDestroy {

    public destinatario: Destinatario;

    public isLoading: boolean;

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
            id: [''],
            logradouro: ['', Validators.required],
            numero: ['', Validators.required],
            bairro: ['', Validators.required],
            municipio: ['', Validators.required],
            estado: ['', Validators.required],
            pais: ['', Validators.required],
        },
    );

    public formModel: FormGroup = this.fb.group({
        id: [''],
        tipoPessoa: ['1', Validators.required],
    });

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: DestinatarioResolveService,
        private service: DestinatarioService,
        private fb: FormBuilder,
        private router: Router) { }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.formModel.addControl('endereco', this.formModelEndereco);
        this.formModel.addControl('pessoaFisica', this.formModelDestinatarioPessoaFisica);
        this.formModel.addControl('pessoaJuridica', this.formModelDestinatarioPessoaJuridica);

        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .do(() => this.isLoading = false)
            .subscribe((destinatario: Destinatario) => {
                this.destinatario = Object.assign(new Destinatario(), destinatario);

                const tipoPessoaFisica: number = 1;
                const tipoPessoaJuridica: number = 2;

                this.formModelEndereco.setValue(this.destinatario.endereco);
                if (this.destinatario.documento.tipo === TipoDocumento.CPF) {

                    this.formModel.controls.tipoPessoa.setValue(tipoPessoaFisica.toString());

                    this.formModel.removeControl('pessoaJuridica');

                } else {
                    this.formModel.controls.tipoPessoa.setValue(tipoPessoaJuridica.toString());

                    this.formModel.removeControl('pessoaFisica');
                }
            });

            this.formModel.controls.tipoPessoa.valueChanges.subscribe((value: number) => {
                this.alterarFormPessoa(value.toString());
            });
    }

    public onSubmit(event: Event): void {
        event.stopPropagation();
        const cmd: DestinatarioEditarComando = new DestinatarioEditarComando(this.formModel.value);
        this.service.put(cmd).subscribe(() => {
            this.router.navigate(['destinatarios']);
        });
    }

    public redirect(event: Event): void {
        this.router.navigate(['destinatarios']);
    }

    public editarDestinatario(formModel: FormGroup): void {
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
        destinatario.id = this.destinatario.id;

        const destinatarioEditarComando: DestinatarioEditarComando = new DestinatarioEditarComando(destinatario);

        this.service.put(destinatarioEditarComando)
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

                this.formModelDestinatarioPessoaFisica.patchValue({ cpf: this.destinatario.documento.numero });
                this.formModelDestinatarioPessoaFisica.patchValue({ nomeRazaoSocial: this.destinatario.nomeRazaoSocial });
                break;
            case '2':
                this.formModel.removeControl('pessoaFisica');
                this.formModel.addControl('pessoaJuridica', this.formModelDestinatarioPessoaJuridica);

                this.formModelDestinatarioPessoaJuridica.patchValue({ cnpj: this.destinatario.documento.numero });
                this.formModelDestinatarioPessoaJuridica.patchValue({ nomeRazaoSocial: this.destinatario.nomeRazaoSocial });
                this.formModelDestinatarioPessoaJuridica.patchValue({ inscricaoEstadual: this.destinatario.inscricaoEstadual });
                break;

            default:
                break;
        }
    }
}
