import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { SharedModule } from '../shared/shared.module';
import { LayoutModule } from './layout/layout.module';
import { StorageModule } from './storage/storage.module';
import { I18nModule } from './i18n/i18n.module';
import { PageReloadModule } from './page-reload/page-reload.module';
import { ErrorInterceptorModule } from './error-interceptor/error-interceptor.module';
import { CORE_CONFIG_TOKEN, CORE_CONFIG } from './core.config';
import { NDDTitlebarGlobalConfigModule } from '../shared/ndd-ng-titlebar/config';

@NgModule({
    imports: [
        SharedModule,
        LayoutModule,
        StorageModule,
        PageReloadModule,
        HttpClientModule,
        ErrorInterceptorModule,
        I18nModule,
        NDDTitlebarGlobalConfigModule.forRoot({
            closeIcon: 'ndd-font ndd-font-close',
        }),
    ],
    exports: [PageReloadModule],
    declarations: [],
    providers: [
        { provide: CORE_CONFIG_TOKEN, useValue: CORE_CONFIG },
        { provide: Window, useValue: window },
    ],
})

export class CoreModule { }
