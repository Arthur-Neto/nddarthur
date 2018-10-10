import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { LocalStorageService } from './local-storage.service';

@NgModule({
    imports: [
        SharedModule,
    ],
    exports: [],
    declarations: [],
    providers: [LocalStorageService],
})
export class StorageModule { }
