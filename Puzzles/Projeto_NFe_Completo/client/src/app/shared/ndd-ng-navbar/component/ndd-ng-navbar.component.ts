import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'ndd-ng-navbar',
    templateUrl: 'ndd-ng-navbar.component.html',
})

export class NDDNavbarComponent {

    @Input() public navbarLogoClass: string;

    @Input() public navbarBreadcrumbHomeName: string;

    @Output() public onNavbarToggle: EventEmitter<void> = new EventEmitter();

    public toggleCollapse(): void {
        this.onNavbarToggle.emit();
    }

}
