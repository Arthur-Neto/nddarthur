import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
    selector: 'ndd-endereco-form',
    templateUrl: './endereco-form.component.html',
})

export class EnderecoFormComponent {
    @Input() public formModel: FormGroup;

    @Output() public submit: EventEmitter<any> = new EventEmitter<any>();

    public onSubmit(event: any): void {
        event.stopPropagation();
        this.submit.emit(this.formModel);

        // tslint:disable-next-line:no-console
        console.log(this.formModel);
    }

    public encontrarErro(formControlName: string): boolean {
        return this.formModel.get(formControlName).hasError('required')
            && this.formModel.get(formControlName).touched;
    }
}
