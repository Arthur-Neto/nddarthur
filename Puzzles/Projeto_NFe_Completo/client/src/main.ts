import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { registerLocaleData } from '@angular/common';
// Brasil
import localePt from '@angular/common/locales/pt';
import '@progress/kendo-angular-intl/locales/pt/all';

import { AppModule } from './app/app.module';

import './main.scss';
import './app/shared/fonts/ndd-ng-icon.font';

((): void => {
    registerLocaleData(localePt, 'pt');

    if (ENV === 'production') {
        enableProdMode();
    }

    platformBrowserDynamic().bootstrapModule(AppModule);
})();
