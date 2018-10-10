import { FormArray } from '@angular/forms';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'pizza-summary',
  templateUrl: 'pizza-summary.component.html',
})

export class PizzaSummaryComponent {
  @Input() public pizzas: FormArray;

  @Input() public total: string;

  @Input() public prices: any;
}
