import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { PizzaPrices, IPizzaPrices, Pizza } from '../shared/pizza.model';
import { PizzaValidators } from '../shared/pizza.validator';
import { PizzaSizes } from '../shared/pizza.enum';

@Component({
  selector: 'pizza-view',
  templateUrl: './pizza-view.component.html',
})

export class PizzaViewComponent implements OnInit {
  private static MIN_LENGTH: number = 3;

  public activePizza: number = 0;
  public total: string = '0';
  public prices: IPizzaPrices = PizzaPrices.ALL_PRICES;

  public form: FormGroup = this.fb.group({
    details: this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      confirm: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required],
      address: ['', [Validators.required, Validators.minLength(PizzaViewComponent.MIN_LENGTH)]],
      postcode: ['', [Validators.required, Validators.minLength(PizzaViewComponent.MIN_LENGTH)]],
    }, { validator: PizzaValidators.checkEmailsMatch }),
    pizzas: this.fb.array([
      this.createPizza(),
    ]),
  });

  constructor(private fb: FormBuilder) {}

  public ngOnInit(): void {
    this.calculateTotal(this.form.get('pizzas').value);
    this.form.get('pizzas')
      .valueChanges
      .subscribe((value: any) => this.calculateTotal(value));
  }

  public calculateTotal(pizzas: Pizza[]): void {
    this.total = Pizza.calculateTotalSet(pizzas).toString();
  }

  public removePizza(index: number): void {
    const control: FormArray = this.form.get('pizzas') as FormArray;
    control.removeAt(index);
  }

  public togglePizza(index: number): void {
    this.activePizza = index;
  }

  public createOrder(orderFormModel: FormGroup): void {
    //
  }

  public addPizza(): void {
    const control: FormArray = this.form.get('pizzas') as FormArray;
    control.push(this.createPizza());
  }

  public createPizza(): FormGroup {
    return this.fb.group({
      size: [PizzaSizes.Small, Validators.required],
      toppings: [[]],
    });
  }
}
