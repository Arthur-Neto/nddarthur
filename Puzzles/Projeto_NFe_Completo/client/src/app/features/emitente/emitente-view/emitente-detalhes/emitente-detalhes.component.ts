import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Subject';
import { Emitente } from './../../shared/emitente.model';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { EmitenteResolveService } from './../../../emitente/shared/emitente-resolver.service';

@Component({
    templateUrl: './emitente-detalhes.component.html',
})

export class EmitenteDetalhesComponent implements OnInit, OnDestroy {
    public emitente: Emitente;
    public availabilityText: string = '';
    public isLoading: boolean = true;
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor
        (
        private resolver: EmitenteResolveService,
        private router: Router,
        private route: ActivatedRoute,
    ) { }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((emitente: Emitente) => {
                this.emitente = Object.assign(new Emitente(), emitente);
                this.isLoading = false;
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public botaoEditar(): void {
        this.router.navigate(['./editar'], { relativeTo: this.route, skipLocationChange: true });
    }

    public redirecionar(): void {
        this.router.navigate(['/emitentes']);
    }
}
