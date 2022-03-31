import { Component, OnInit } from '@angular/core';
import { Pizza } from '../pizza';
import { PizzaDataSharingService } from '../pizza-data-sharing.service';
import { PizzaService } from '../pizza.service';

@Component({
  selector: 'app-pizza-cart',
  templateUrl: './pizza-cart.component.html',
  styleUrls: ['./pizza-cart.component.css']
})
export class PizzaCartComponent implements OnInit {
  pizzaCart: Pizza[] = [];
  constructor(private pizzaService:PizzaService, private pizzaDataSharingService: PizzaDataSharingService) { }
  totalOrderPrice: number=0;

  ngOnInit() {
    this.pizzaDataSharingService.pizzaAddedTocart.subscribe(x => {
      if (!this.pizzaCart.some(z=>z.id==x.id)) {
        this.pizzaCart.push(x);
        this.calculateTotalOrderPrice();
      }
      this.pizzaCart.map(pizza => {
        if (pizza.id == x.id) {
          pizza.selectedPizzaCount = x.selectedPizzaCount;
          this.calculateTotalOrderPrice();
          return;
        }

      });
    });
    this.pizzaDataSharingService.pizzaRemovedFromcart.subscribe(x=>{

      this.pizzaCart.map(pizza => {
        if (pizza.id == x.id) {
          if(pizza.selectedPizzaCount==0){
            this.pizzaCart = this.pizzaCart.filter(item => item.id !== x.id);
            this.calculateTotalOrderPrice();
            return;
          }
          pizza.selectedPizzaCount = x.selectedPizzaCount;
          this.calculateTotalOrderPrice();
          return;
        }
      });
    });
  }

  private calculateTotalOrderPrice() {
   this.totalOrderPrice =0; 
    this.pizzaCart.map(pizza => {
     this.totalOrderPrice += (pizza.price * pizza.selectedPizzaCount);
    });
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

  chekoutCart()
  {

  }

}
