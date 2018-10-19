import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup } from '@angular/forms';
import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'ndd-produto-form',
    templateUrl: './produto-form.component.html',
})

export class ProdutoFormComponent {

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

        // tslint:disable-next-line:no-console
        console.log(this.formModel);
    }

    public encontrarErro(controlName: string): boolean {
        return this.formModel.get(controlName).hasError('required')
            && this.formModel.get(controlName).touched;
    }
}
