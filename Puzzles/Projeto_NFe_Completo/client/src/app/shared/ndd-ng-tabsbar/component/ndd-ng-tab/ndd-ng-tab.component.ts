import { Component, OnInit, OnDestroy, Input, EventEmitter } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { Subject } from 'rxjs/Subject';

import 'rxjs/add/operator/takeUntil';

import { NDDTabsbarComponent } from '../ndd-ng-tabsbar.component';

@Component({
    selector: 'ndd-ng-tab',
    templateUrl: './ndd-ng-tab.component.html',
})

export class NDDTabComponent implements OnInit, OnDestroy {

    @Input() public tabId: string = 'ndd-ng-tab';
    @Input() public tabTitle: string;
    @Input() public tabRoute: string;
    @Input() public tabRouteParams?: any;
    @Input() public tabDisabled: boolean;

    public i18n: boolean;

    private currentLocation: string;
    private ngUnsubscribe: Subject<void> = new Subject<void>();
    private onTabSelect: EventEmitter<NDDTabComponent>;

    constructor(private parent: NDDTabsbarComponent, private router: Router) { }

    public ngOnInit(): void {
        this.i18n = this.parent.tabsbarI18n;
        this.onTabSelect = this.parent.onTabSelect;

        this.currentLocation = this.router.url;

        this.router.events
            .takeUntil(this.ngUnsubscribe)
            .subscribe((event: any) => {
                if (event instanceof NavigationEnd) {
                    this.currentLocation = event.urlAfterRedirects;
                }
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public isActive(): boolean {
        return !this.currentLocation ? false : this.currentLocation.includes(this.tabRoute);
    }

    public selectTab(): void {
        if (!this.isActive()) {
            this.onTabSelect.next(this);
        }
    }
}
