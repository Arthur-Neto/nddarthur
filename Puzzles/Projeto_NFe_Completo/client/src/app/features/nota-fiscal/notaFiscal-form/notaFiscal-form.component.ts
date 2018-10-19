import { Router, ActivatedRoute } from '@angular/router';
import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { Destinatario } from '../../destinatario/shared/model/destinatario.model';
import { Emitente } from '../../emitente/shared/emitente.model';
import { Transportador } from '../../transportador/shared/model/transportador.model';
import { DestinatarioService } from '../../destinatario/shared/destinatario.service';
import { EmitenteService } from '../../emitente/shared/emitente.service';
import { TransportadorService } from '../../transportador/shared/transportador.service';

@Component({
    selector: 'ndd-nota-form',
    templateUrl: './notaFiscal-form.component.html',
})

export class NotaFiscalFormComponent implements OnInit {
    @Input() public formModel: FormGroup;

    @Output() public submit: EventEmitter<any> = new EventEmitter<any>();

    public isLoading: boolean = false;

    public defaultDestinatario: Destinatario = { nomeRazaoSocial: 'Selecione um destinatário...' };
    public dataDestinatarios: Destinatario[];
    public destinatarios: Destinatario[];

    public defaultEmitente: Emitente = { razaoSocial: 'Selecione um emitente...' };
    public dataEmitentes: Emitente[];
    public emitentes: Emitente[];

    public defaultTransportador: Transportador = { nomeRazaoSocial: 'Selecione um transportador...' };
    public dataTransportadores: Transportador[];
    public transportadores: Transportador[];

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private destinatarioService: DestinatarioService,
        private emitenteService: EmitenteService,
        private transportadorService: TransportadorService) { }

    public ngOnInit(): void {
        this.isLoading = true;
        this.destinatarioService.getAll()
        .subscribe((destinatarios: Destinatario[]) => {
            this.destinatarios = destinatarios;
            this.dataDestinatarios = this.destinatarios.slice();
        });
        this.emitenteService.getAll()
        .subscribe((emitentes: Emitente[]) => {
            this.emitentes = emitentes;
            this.dataEmitentes = this.emitentes.slice();
        });
        this.transportadorService.getAll()
        .do(() => this.isLoading = false)
        .subscribe((transportadores: Transportador[]) => {
            this.transportadores = transportadores;
            this.dataTransportadores = this.transportadores.slice();
        });
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

    public onFilterDestinatario(value: any): void {
        this.dataDestinatarios = this.destinatarios.filter((s: any) => s.name.toLowerCase().indexOf(value.toLowerCase()) !== -1);
    }

    public onFilterTransportador(value: any): void {
        this.dataTransportadores = this.transportadores.filter((s: any) => s.name.toLowerCase().indexOf(value.toLowerCase()) !== -1);
    }

    public onFilterEmitente(value: any): void {
        this.dataEmitentes = this.emitentes.filter((s: any) => s.name.toLowerCase().indexOf(value.toLowerCase()) !== -1);
    }

    public selecionarDestinatario(destinatario: Destinatario): void {
        this.formModel.controls.notaFiscal.patchValue({destinatarioId: destinatario.id});
    }

    public selecionarEmitente(emitente: Emitente): void {
        this.formModel.controls.notaFiscal.patchValue({emitenteId: emitente.id});
    }

    public selecionarTransportador(transportador: Transportador): void {
        this.formModel.controls.notaFiscal.patchValue({transportadorId: transportador.id});

        // tslint:disable-next-line:no-console
        console.log(this.formModel);
    }
}
