import { NgModule, LOCALE_ID } from '@angular/core';
import { MessageService } from '@progress/kendo-angular-l10n';
import { NDDKendoTranslationService } from './ndd-kendo-translation.service';

@NgModule({
    providers: [
        { provide: MessageService, useClass: NDDKendoTranslationService },
        // Angular e Kendo - pt is load in main.ts
        { provide: LOCALE_ID, useValue: 'pt' },
    ],
})
export class I18nModule {
}
