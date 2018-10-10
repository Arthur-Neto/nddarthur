import { NgModule } from '@angular/core';
import { PageNotFoundComponent } from './page-not-found.component';
import { PageNotFoundRoutingModule } from './page-not-found-routing.module';
import { SharedModule } from '../../../shared/shared.module';

@NgModule({
    imports: [
        SharedModule,
        PageNotFoundRoutingModule,
    ],
    exports: [],
    declarations: [PageNotFoundComponent],
    providers: [],
})
export class PageNotFoundModule {}
