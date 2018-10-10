import { NgModule } from '@angular/core';
import { PageNotFoundComponent } from './page-not-found.component';
import { RouterModule, Routes } from '@angular/router';

const pageNotFoundRoutes: Routes = [
    {
        path: '',
        component: PageNotFoundComponent,
    },
];
@NgModule({
    imports: [RouterModule.forChild(pageNotFoundRoutes)],
    exports: [RouterModule],
})
export class PageNotFoundRoutingModule { }
