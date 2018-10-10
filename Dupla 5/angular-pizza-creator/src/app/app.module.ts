import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { PizzaModule } from './features/pizzas/pizzas.module';

@NgModule({
  imports: [
    BrowserModule,
    PizzaModule,
  ],
  bootstrap: [
    AppComponent,
  ],
  declarations: [
    AppComponent,
  ],
})
export class AppModule {}
