import { Component, Input } from '@angular/core';
import { INDDBreadcrumb } from './../ndd-ng-breadcrumb.model';

@Component({
    selector: 'ndd-ng-breadcrumb-popup',
    templateUrl: './ndd-ng-breadcrumb-popup.component.html',
})
export class NDDBreadcrumbPopupComponent {
    @Input() public isI18n: boolean = false;
    @Input() public isOpen: boolean = false;
    @Input() public breadcrumbs: INDDBreadcrumb[] = [];

    public redirect(event: any): void {
        // Fazemos o stopImmediatePropagation para evitar que o clique na opção "..." do breadcrumb
        // Seja invocado.
        event.stopImmediatePropagation();
    }
}
