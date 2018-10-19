import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { Transportador, TransportadorEditarComando } from '../shared/model/transportador.model';
import { Subject } from 'rxjs/Subject';
import { TransportadorResolveService, TransportadorService } from '../shared/transportador.service';
import { Documento } from './../../../shared/models/documento/documento.model';
import { TipoDocumento } from './../../../shared/models/documento/documento.enum';
import { Endereco } from '../../endereco/shared/model/endereco.model';

@Component({
    templateUrl: './transportador-editar.component.html',
})
export class TransportadorEditarComponent implements OnInit, OnDestroy {

    public transportador: Transportador;

    public isLoading: boolean;

    public tipoPessoaFisica: string = '1';

    public tipoPessoaJuridica: string = '2';

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

    constructor(private resolver: TransportadorResolveService,
        private service: TransportadorService,
        private fb: FormBuilder,
        private router: Router) { }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.formModel.addControl('endereco', this.formModelEndereco);
        this.formModel.addControl('pessoaFisica', this.formModelTransportadorPessoaFisica);
        this.formModel.addControl('pessoaJuridica', this.formModelTransportadorPessoaJuridica);

        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .do(() => this.isLoading = false)
            .subscribe((transportador: Transportador) => {
                this.transportador = Object.assign(new Transportador(), transportador);

                const tipoPessoaFisica: number = 1;
                const tipoPessoaJuridica: number = 2;

                this.formModelEndereco.setValue(this.transportador.endereco);
                if (this.transportador.documento.tipo === TipoDocumento.CPF) {

                    this.formModel.controls.tipoPessoa.setValue(this.tipoPessoaFisica);

                    this.preencherFormularioPessoaFisica();

                } else {
                    this.formModel.controls.tipoPessoa.setValue(this.tipoPessoaJuridica);

                    this.preencherFormularioPessoaJuridica();
                }
            });

        this.formModel.controls.tipoPessoa.valueChanges.subscribe((value: string) => {
            this.alterarFormPessoa(value);
        });
    }

    public onSubmit(event: Event): void {
        event.stopPropagation();
        const cmd: TransportadorEditarComando = new TransportadorEditarComando(this.formModel.value);
        this.service.put(cmd).subscribe(() => {
            this.router.navigate(['transportadores']);
        });
    }

    public redirect(event: Event): void {
        this.router.navigate(['transportadores']);
    }

    public editarTransportador(formModel: FormGroup): void {
        this.isLoading = true;

        let transportador: Transportador;

        let documento: Documento;

        if (this.formModel.value.tipoPessoa === '1') {
            transportador = this.formModel.value.pessoaFisica;
            documento = new Documento(this.formModel.value.pessoaFisica.cpf, TipoDocumento.CPF);
        } else {
            transportador = this.formModel.value.pessoaJuridica;
            documento = new Documento(this.formModel.value.pessoaJuridica.cnpj, TipoDocumento.CNPJ);
        }

        const endereco: Endereco = this.formModel.value.endereco;

        transportador.documento = documento;
        transportador.endereco = endereco;
        transportador.id = this.transportador.id;

        const transportadorEditarComando: TransportadorEditarComando = new TransportadorEditarComando(transportador);

        this.service.put(transportadorEditarComando)
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

                this.preencherFormularioPessoaFisica();

                break;
            case '2':
                this.formModel.removeControl('pessoaFisica');
                this.formModel.addControl('pessoaJuridica', this.formModelTransportadorPessoaJuridica);

                this.preencherFormularioPessoaJuridica();

                break;

            default:
                break;
        }
    }

    private preencherFormularioPessoaFisica(): void {
        this.formModelTransportadorPessoaFisica.patchValue({ cpf: this.transportador.documento.numero });
        this.formModelTransportadorPessoaFisica.patchValue({ nomeRazaoSocial: this.transportador.nomeRazaoSocial });
        this.formModelTransportadorPessoaFisica.patchValue({ responsabilidadeFrete: this.transportador.responsabilidadeFrete });
    }

    private preencherFormularioPessoaJuridica(): void {
        this.formModelTransportadorPessoaJuridica.patchValue({ cnpj: this.transportador.documento.numero });
        this.formModelTransportadorPessoaJuridica.patchValue({ nomeRazaoSocial: this.transportador.nomeRazaoSocial });
        this.formModelTransportadorPessoaJuridica.patchValue({ inscricaoEstadual: this.transportador.inscricaoEstadual });
        this.formModelTransportadorPessoaJuridica.patchValue({ responsabilidadeFrete: this.transportador.responsabilidadeFrete });
    }
}
