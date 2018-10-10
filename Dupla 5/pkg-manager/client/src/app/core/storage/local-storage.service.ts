import { Injectable, Inject } from '@angular/core';
import { LocalStorageKeys } from './local-storage.enum';

@Injectable()
export class LocalStorageService {
    constructor( @Inject(Window) private windowRef: Window) { }

    public setValue(key: LocalStorageKeys, value: string): void {
        this.windowRef.localStorage.setItem(key.toString(), value);
    }

    public getValue(key: LocalStorageKeys): string {
        return this.windowRef.localStorage.getItem(key.toString());
    }

    public deleteValue(key: LocalStorageKeys): void {
        delete this.windowRef.localStorage[key.toString()];
    }
}
