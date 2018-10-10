import { MessageService } from '@progress/kendo-angular-l10n';
import { Injectable } from '@angular/core';
import {
    NDDI18nKendoTranslationGridServiceConfig,
    NDDI18nKendoTranslationDatePickerServiceConfig,
    NDDI18nKendoTranslationTimePickerServiceConfig,
} from './ndd-kendo-resources.model';

@Injectable()
export class NDDKendoTranslationService extends MessageService {
    public get(key: string): string {
        let translation: string;
        const keys: string[] = key.split('.');
        const messageName: string = keys[keys.length - 1];

        if (key.startsWith('kendo.grid')) {
            translation = NDDI18nKendoTranslationGridServiceConfig.resources[messageName];
        } else if (key.startsWith('kendo.datepicker')) {
            translation = NDDI18nKendoTranslationDatePickerServiceConfig.resources[messageName];
        } else if (key.startsWith('kendo.timepicker')) {
            translation = NDDI18nKendoTranslationTimePickerServiceConfig.resources[messageName];
        }

        return translation;
    }
}
