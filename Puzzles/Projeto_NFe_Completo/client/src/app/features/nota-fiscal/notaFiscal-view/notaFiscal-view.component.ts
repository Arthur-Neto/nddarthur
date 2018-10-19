import { Component, OnInit, OnDestroy } from '@angular/core';

import { Subject } from 'rxjs/Subject';

import { NotaFiscal } from '../shared/model/notaFiscal.model';
import { NotaFiscalResolveService } from '../shared/notaFiscal.service';

@Component({
    templateUrl: './notaFiscal-view.component.html',
})
export class NotaFiscalViewComponent implements OnInit, OnDestroy {
    public title: string;

    public infoItems: object[];

    private notaFiscal: NotaFiscal;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: NotaFiscalResolveService) { }

    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((notaFiscal: NotaFiscal) => {
                this.notaFiscal = notaFiscal;
                this.createProperty();
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public createProperty(): void {
        this.title = this.notaFiscal.chaveAcesso;
        const dataEmissao: string = 'Data Emissão: ' + this.notaFiscal.dataEmissao;
        const dataEntrada: string = 'Data Entrada: ' + this.notaFiscal.dataEntrada;

        this.infoItems = [
            {
                value: dataEntrada,
                description: dataEntrada,
            },
            {
                value: dataEmissao,
                description: dataEmissao,
            },
        ];
    }
}
