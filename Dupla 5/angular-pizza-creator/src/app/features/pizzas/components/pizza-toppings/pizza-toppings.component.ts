import { Component, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { Topping } from '../../shared/pizza.enum';
import { Toppings } from '../../shared/pizza.model';

const PIZZA_TOPPINGS_ACCESSOR: any = {
  provide: NG_VALUE_ACCESSOR,
  // tslint:disable-next-line:no-forward-ref no-use-before-declare
  useExisting: forwardRef(() => PizzaToppingsComponent),
  multi: true,
};

@Component({
  selector: 'pizza-toppings',
  providers: [PIZZA_TOPPINGS_ACCESSOR],
  templateUrl: './pizza-toppings.component.html',
})
export class PizzaToppingsComponent implements ControlValueAccessor {
  public toppings: Topping[] = Toppings.ALL_TOPPINGS;
  public value: Topping[] = [];
  public focused: string;

  private onTouch: Function;
  private onModelChange: Function;

  public registerOnChange(fn: Function): void {
    this.onModelChange = fn;
  }

  public registerOnTouched(fn: Function): void {
    this.onTouch = fn;
  }

  public writeValue(value: any): void {
    this.value = value;
  }

  public updateTopping(topping: Topping): void {
    if (this.value.indexOf(topping) >= 0) {
      this.value = this.value.filter((x: Topping) => topping !== x);
    } else {
      this.value = this.value.concat([topping]);
    }
    this.onModelChange(this.value);
  }

  public onBlur(value: string): void {
    this.focused = '';
  }

  public onFocus(value: string): void {
    this.focused = value;
    this.onTouch();
  }
}
