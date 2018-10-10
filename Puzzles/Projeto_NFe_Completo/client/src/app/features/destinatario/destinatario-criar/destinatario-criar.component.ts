import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

import { Subject } from 'rxjs/Subject';

import { Destinatario, DestinatarioCriarComando } from '../shared/model/destinatario.model';
import { DestinatarioService } from '../shared/destinatario.service';

@Component({
    templateUrl: './destinatario-criar.component.html',
})
export class DestinatarioCriarComponent implements OnInit, OnDestroy {

    public formModel: FormGroup;

    public destinatario: Destinatario;

    public isLoading: boolean;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private service: DestinatarioService,
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
        this.isLoading = false;
    }

    public onSubmit(event: Event): void {
        event.stopPropagation();
        const cmd: DestinatarioCriarComando = new DestinatarioCriarComando(this.formModel.value);
        this.service.post(cmd).subscribe(() => {
            this.router.navigate(['destinatarios']);
        });
    }

    public redirect(event: Event): void {
        this.router.navigate(['destinatarios']);
    }
}
