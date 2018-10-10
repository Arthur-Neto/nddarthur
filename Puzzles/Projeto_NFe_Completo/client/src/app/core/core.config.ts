import { InjectionToken } from '@angular/core';
import { LocalStorageKeys } from './storage/local-storage.enum';

export interface ICoreConfig {
    apiEndpoint: string;
    apiResourcesEndpoint: string;
}

export const CORE_CONFIG: ICoreConfig = JSON.parse(localStorage.getItem(LocalStorageKeys.Config));

export const CORE_CONFIG_TOKEN: InjectionToken<ICoreConfig> = new InjectionToken<ICoreConfig>('core.config');
