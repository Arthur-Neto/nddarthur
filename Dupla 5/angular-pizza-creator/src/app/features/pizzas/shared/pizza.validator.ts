import { AbstractControl, ValidationErrors } from '@angular/forms';

export class PizzaValidators {
  public static checkEmailsMatch(control: AbstractControl): ValidationErrors | null {
    const email: AbstractControl = control.get('email');
    const confirm: AbstractControl = control.get('confirm');
    if (!(email && confirm)) return null;

    return email.value === confirm.value ? null : { nomatch: true };
  }
}
