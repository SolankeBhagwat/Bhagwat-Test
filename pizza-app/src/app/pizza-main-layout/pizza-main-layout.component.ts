import { Component, OnInit, Input } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import {
  debounceTime, distinctUntilChanged, switchMap
} from 'rxjs/operators';
import { Pizza } from '../pizza';
import { PizzaDataSharingService } from '../pizza-data-sharing.service';
import { PizzaService } from '../pizza.service';

@Component({
  selector: 'app-pizza-main-layout',
  templateUrl: './pizza-main-layout.component.html',
  styleUrls: ['./pizza-main-layout.component.css']
})

export class PizzaMainLayoutComponent implements OnInit {
  pizzas: Pizza[];
  pizzas$: Observable<Pizza[]>;
  private searchTerms = new Subject<any>();

  selectedBase: string;
  selectedType: string;
  price: number;
  pizzaToggle: string;

  bases = [
    { value: 'Thin Crust', viewValue: 'Thin Crust' },
    { value: 'Regular base', viewValue: 'Regular base' },
    { value: 'Flat bread', viewValue: 'Flat bread' },
    { value: 'Multigrain ', viewValue: 'Multigrain' }
  ];

  types = [
    { value: 'Cheese burst', viewValue: 'Cheese burst' },
    { value: 'Cheese topping', viewValue: 'Cheese topping' },
    { value: 'No cheese ', viewValue: 'No cheese' }
  ];


  constructor(private pizzaService: PizzaService, private pizzaDataSharingService: PizzaDataSharingService) { }

  ngOnInit(): void {
    this.pizzas$ = this.searchTerms.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      switchMap((term: string) => this.pizzaService.searchPizza(term)),
    );

  }

  setToggleValue(term: any): void {

    this.pizzaToggle = term
    this.search();

  }

  search(): void {
    if (!this.selectedBase)
      this.selectedBase = '';
    if (!this.selectedType)
      this.selectedType = '';
    if (!this.pizzaToggle)
      this.pizzaToggle = '';

    let term = [this.pizzaToggle, this.selectedBase, this.selectedType];
    this.searchTerms.next(term);
  }

  addToCart(pizza: Pizza) {
    pizza.isPizzaSelected = true;
    pizza.selectedPizzaCount += 1;
    this.pizzaDataSharingService.pizzaAddedTocart.next(pizza);
  }

  removeFromCart(pizza: Pizza) {
    if (pizza.selectedPizzaCount > 0) {
      pizza.selectedPizzaCount -= 1;
      if (pizza.selectedPizzaCount == 0) {
        pizza.isPizzaSelected = false;
      }
    }
    this.pizzaDataSharingService.pizzaRemovedFromcart.next(pizza);
  }

}
