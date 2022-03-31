
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Pizza } from './pizza';


@Injectable({
               providedIn: 'root'
})
export class PizzaDataSharingService {
 public pizzaAddedTocart: Subject<Pizza> = new Subject<Pizza>();
 public pizzaRemovedFromcart: Subject<Pizza> = new Subject<Pizza>();
}