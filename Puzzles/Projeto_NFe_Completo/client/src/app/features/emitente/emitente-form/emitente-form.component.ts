import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup } from '@angular/forms';
import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'ndd-emitente-form',
    templateUrl: './emitente-form.component.html',
})

export class EmitenteFormComponent {

    @Input() public formModel: FormGroup;

    @Output() public submit: EventEmitter<any> = new EventEmitter<any>();

    constructor(
        private router: Router,
        private route: ActivatedRoute) { }

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
}
