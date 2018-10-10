import { Component, Input, Output, EventEmitter } from '@angular/core';
import { NDDTabComponent } from './';

@Component({
    selector: 'ndd-ng-tabsbar',
    templateUrl: './ndd-ng-tabsbar.component.html',
})
export class NDDTabsbarComponent {

    @Input() public tabsbarI18n: boolean = false;
    @Output() public onTabSelect: EventEmitter<NDDTabComponent> = new EventEmitter();

}
