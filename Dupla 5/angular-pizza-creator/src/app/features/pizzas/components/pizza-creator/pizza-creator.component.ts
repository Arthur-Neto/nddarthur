import { FormArray } from '@angular/forms';
import { Component, Input, EventEmitter, Output, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'pizza-creator',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: 'pizza-creator.component.html',
})
export class PizzaCreatorComponent {
  @Input() public pizzas: FormArray;

  @Output() public add: EventEmitter<void> = new EventEmitter<void>();

  @Output() public remove: EventEmitter<number> = new EventEmitter<number>();

  @Output() public toggle: EventEmitter<number> = new EventEmitter<number>();

  get openPizza(): number {
    return this.visiblePizza;
  }

  set openPizza(index: number) {
    this.visiblePizza = index;
    if (index >= 0) {
      this.toggle.emit(index);
    }
  }

  private visiblePizza: number = 0;

  public addPizza(): void {
    this.add.emit();
    this.openPizza = this.pizzas.length - 1;
  }

  public removePizza(index: number): void {
    this.remove.emit(index);
    this.openPizza = this.pizzas.length - 1;
  }

  public togglePizza(index: number): void {
    if (this.openPizza === index) {
      this.openPizza = -1;
    } else {
      this.openPizza = index;
    }
  }
}
