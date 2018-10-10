import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { PizzaFormComponent } from './components/pizza-form/pizza-form.component';
import { PizzaViewerComponent } from './components/pizza-viewer/pizza-viewer.component';
import { PizzaSizeComponent } from './components/pizza-size/pizza-size.component';
import { PizzaToppingsComponent } from './components/pizza-toppings/pizza-toppings.component';
import { PizzaViewComponent } from './pizza-view/pizza-view.component';
import { PizzaCreatorComponent } from './components/pizza-creator/pizza-creator.component';
import { PizzaSummaryComponent } from './components/pizza-summary/pizza-summary.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
  ],
  declarations: [
    PizzaFormComponent,
    PizzaViewerComponent,
    PizzaSizeComponent,
    PizzaToppingsComponent,
    PizzaViewComponent,
    PizzaCreatorComponent,
    PizzaSummaryComponent,
  ],
  exports: [
    PizzaViewComponent,
  ],
})
export class PizzaModule {}
