import { AbstractControl, ValidationErrors } from '@angular/forms';

export class ProductValidators {
  public static checkProductDates(control: AbstractControl): ValidationErrors | null {
    const manufacture: AbstractControl = control.get('manufacture');
    const expiration: AbstractControl = control.get('expiration');
    const dateTimeNow: Date = new Date();
    const invalidYear: number = 2000;

    if (!(manufacture && expiration)) return null;
    if (manufacture.value > dateTimeNow) return { nomatch: true };
    if (manufacture.value < invalidYear || expiration.value < invalidYear) return { nomatch: true };

    return manufacture.value < expiration.value ? null : { nomatch: true };
  }
}
