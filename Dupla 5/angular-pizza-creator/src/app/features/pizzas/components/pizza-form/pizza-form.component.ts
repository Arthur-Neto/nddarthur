import { FormGroup } from '@angular/forms';
import { Component, ChangeDetectionStrategy, Input, Output, EventEmitter } from '@angular/core';
import { IPizzaPrices } from '../../shared/pizza.model';

@Component({
  selector: 'pizza-form',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: 'pizza-form.component.html',
})
export class PizzaFormComponent {
  @Input() public formModel: FormGroup;

  @Input() public total: string;

  @Input() public prices: IPizzaPrices;

  @Output() public add: EventEmitter<void> = new EventEmitter<void>();

  @Output() public remove: EventEmitter<number> = new EventEmitter<number>();

  @Output() public toggle: EventEmitter<number> = new EventEmitter<number>();

  @Output() public submit: EventEmitter<FormGroup> = new EventEmitter<FormGroup>();

  public onAddPizza(): void {
    this.add.emit();
  }

  public onRemovePizza(index: number): void {
    this.remove.emit(index);
  }

  public onToggle(index: number): void  {
    this.toggle.emit(index);
  }

  public onSubmit(event: Event): void {
    event.stopPropagation();
    this.submit.emit(this.formModel);
  }

}
