import { INDDBreadcrumb } from './../../../../shared/ndd-ng-breadcrumb/component/ndd-ng-breadcrumb.model';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { Emitente, EmitenteEditarComando } from './../../shared/emitente.model';
import { Subject } from 'rxjs/Subject';
import { EmitenteService } from '../../shared/emitente.service';
import { Documento } from './../../../../shared/models/documento/documento.model';
import { TipoDocumento } from './../../../../shared/models/documento/documento.enum';
import { Endereco } from './../../../endereco/shared/model/endereco.model';
import { EmitenteResolveService } from '../../shared/emitente-resolver.service';

@Component({
    templateUrl: './emitente-editar.component.html',
})
export class EmitenteEditarComponent implements OnInit, OnDestroy {

    public emitente: Emitente;
    public endereco: Endereco;

    public isLoading: boolean;

    public formModelEmitente: FormGroup = this.fb.group(
        {
            id: [''],
            nomeFantasia: ['', Validators.required],
            razaoSocial: ['', Validators.required],
            inscricaoEstadual: ['', Validators.required],
            inscricaoMunicipal: ['', Validators.required],
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

    public formModel: FormGroup = this.fb.group({});

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: EmitenteResolveService,
        private service: EmitenteService,
        private fb: FormBuilder,
        private router: Router) { }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public ngOnInit(): void {
        this.isLoading = true;

        this.formModel.addControl('emitente', this.formModelEmitente);
        this.formModel.addControl('endereco', this.formModelEndereco);

        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .do(() => this.isLoading = false)
            .subscribe((emitente: Emitente) => {
                this.emitente = Object.assign(new Emitente(), emitente);
                this.endereco = Object.assign(new Endereco(), emitente.endereco);

                this.formModel.controls.emitente.patchValue(this.emitente);
                this.formModel.controls.endereco.patchValue(this.emitente.endereco);
                this.formModel.controls.emitente.get('cnpj').patchValue(this.emitente.cnpj.numero);

                // Teste this.formModelEmitente.setValue(this.emitente);
                // Teste this.formModelEndereco.setValue(this.endereco);
            });
    }

    public onSubmit(event: Event): void {
        event.stopPropagation();
        const cmd: EmitenteEditarComando = new EmitenteEditarComando(this.formModel.value);
        this.service.put(cmd).subscribe(() => {
            this.router.navigate(['emitentes']);
        });
    }

    public redirect(event: Event): void {
        this.router.navigate(['emitentes']);
    }

    public editarEmitente(formModel: FormGroup): void {
        this.isLoading = true;

        this.emitente = this.formModel.value.emitente;
        this.endereco = this.formModel.value.endereco;

        this.emitente.cnpj = new Documento(this.formModelEmitente.value.cnpj, TipoDocumento.CNPJ);
        this.emitente.endereco = this.endereco;
        this.emitente.id = this.formModel.value.emitente.id;

        const emitenteEditarComando: EmitenteEditarComando = new EmitenteEditarComando(this.emitente);

        this.service.put(emitenteEditarComando)
            .take(1)
            .do(() => this.isLoading = false)
            .subscribe(() => {
                this.router.navigate(['emitentes']);
            });

    }
}
