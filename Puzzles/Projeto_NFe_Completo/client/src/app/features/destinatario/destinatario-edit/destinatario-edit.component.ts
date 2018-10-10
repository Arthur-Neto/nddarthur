import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';

import { Destinatario, DestinatarioEditComando } from '../shared/model/destinatario.model';
import { Subject } from 'rxjs/Subject';
import { DestinatarioResolveService, DestinatarioService } from '../shared/destinatario.service';

@Component({
    templateUrl: './destinatario-edit.component.html',
})
export class DestinatarioEditComponent implements OnInit, OnDestroy {

    public formModel: FormGroup;

    public destinatario: Destinatario;

    public isLoading: boolean;

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
        this.formModel = this.fb.group({
            id: [''],
        });
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .do(() => this.isLoading = false)
            .subscribe((destinatario: Destinatario) => {
                this.destinatario = Object.assign(new Destinatario(), destinatario);
                this.formModel.patchValue(this.destinatario);
            });
    }

    public onSubmit(event: Event): void {
        event.stopPropagation();
        const cmd: DestinatarioEditComando = new DestinatarioEditComando(this.formModel.value);
        this.service.put(cmd).subscribe(() => {
            this.router.navigate(['destinatarios']);
        });

    }

    public redirect(event: Event): void {
        this.router.navigate(['destinatarios']);
    }
}
