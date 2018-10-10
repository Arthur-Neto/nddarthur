import { Component, Input } from '@angular/core';
import { INDDTitlebarInfoItem } from './shared';

@Component({
    selector: 'ndd-ng-titlebar-info',
    templateUrl: './ndd-ng-titlebar-info.component.html',
})
export class NDDTitlebarInfoComponent {
    @Input() public infoItem: INDDTitlebarInfoItem;
    @Input() public infoI18n: boolean = false;
}
