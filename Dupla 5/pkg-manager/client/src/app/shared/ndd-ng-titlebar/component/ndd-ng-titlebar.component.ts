import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NDDTitlebarGlobalConfig } from '../config/ndd-ng-titlebar-config.model';
import { INDDTitlebarInfoItem } from './ndd-ng-titlebar-info/shared/ndd-ng-titlebar-info.model';

@Component({
    selector: 'ndd-ng-titlebar',
    templateUrl: './ndd-ng-titlebar.component.html',
})
export class NDDTitlebarComponent {
    private static INFO_LIMIT: number = 2;

    @Input() public titlebarId: string = 'ndd-ng-titlebar';
    @Input() public titlebarTitle: string;
    @Input() public titlebarIcon: string;
    @Input() public titlebarInfoItems: INDDTitlebarInfoItem[];
    @Input() public titlebarRouterToReturnOnClose: any[];
    @Input() public titlebarHeaderI18n: boolean = false;
    @Input() public titlebarInfoI18n: boolean = false;
    @Input() public titlebarShowCloseButton: boolean = true;

    @Output() public onTitlebarClose: EventEmitter<null> = new EventEmitter();

    constructor(public config: NDDTitlebarGlobalConfig, private route: ActivatedRoute, private router: Router) { }

    public close(): void {
        this.onTitlebarClose.emit();

        if (this.titlebarRouterToReturnOnClose) {
            this.router.navigate([this.titlebarRouterToReturnOnClose], { relativeTo: this.route });

            return;
        }

        this.router.navigate(['../'], { relativeTo: this.route });
    }

    public getMobileInfoItems(): INDDTitlebarInfoItem[] {
        if (this.titlebarInfoItems) {
            // Limita o número de informações em 2, quando for mobile.
            if (this.titlebarInfoItems.length > NDDTitlebarComponent.INFO_LIMIT) {
                return [this.titlebarInfoItems[0], this.titlebarInfoItems[1]];
            }

            return this.titlebarInfoItems;
        }

        return [];
    }
}
