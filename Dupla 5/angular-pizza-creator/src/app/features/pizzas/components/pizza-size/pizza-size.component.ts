import { Component, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

export const PIZZA_SIZE_ACCESSOR: any = {
  provide: NG_VALUE_ACCESSOR,
  // tslint:disable-next-line:no-forward-ref no-use-before-declare
  useExisting: forwardRef(() => PizzaSizeComponent),
  multi: true,
};

@Component({
  selector: 'pizza-size',
  providers: [PIZZA_SIZE_ACCESSOR],
  templateUrl: './pizza-size.component.html',
})
export class PizzaSizeComponent implements ControlValueAccessor {

  public sizes: any[] = [
    { type: 'large', inches: 13 },
    { type: 'medium', inches: 11 },
    { type: 'small', inches: 9 },
  ];

  private onModelChange: Function;
  private onTouch: Function;
  // tslint:disable-next-line:no-unused-variable
  private value: string;
  // tslint:disable-next-line:no-unused-variable
  private focused: string;

  public registerOnChange(fn: Function): void {
    this.onModelChange = fn;
  }

  public registerOnTouched(fn: Function): void {
    this.onTouch = fn;
  }

  public writeValue(value: string): void {
    this.value = value;
  }

  public onChange(value: string): void {
    this.value = value;
    this.onModelChange(value);
  }

  public onBlur(value: string): void {
    this.focused = '';
  }

  public onFocus(value: string): void {
    this.focused = value;
    this.onTouch();
  }
}
