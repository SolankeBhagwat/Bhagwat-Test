import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { Pizza } from "./pizza";
import { PizzaOrder } from "./pizza-order";

@Injectable({
  providedIn: "root",
})
export class OrderService {
  private pizzaURL = " http://localhost:5000/api/pizza";

  constructor(private http: HttpClient) {}

  placeOrder(pizzaOrder: PizzaOrder) {
    const url = this.pizzaURL + "/place-order";
    this.http.post(url,pizzaOrder).pipe(
      catchError(this.handleError<Pizza>(`failed to save pizza`))
    );

  }
  getPizza(id: number): Observable<Pizza> {
    const url = this.pizzaURL + "/get-pizza/" + { id };
    return this.http.get<Pizza>(url).pipe(
      tap((_) => this.log(`fetched pizza id=${id}`)),
      catchError(this.handleError<Pizza>(`getPizza id=${id}`))
    );
  }

  private handleError<T>(operation = "operation", result?: T) {
    return (error: any): Observable<T> => {
      console.error(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }
  private log(message: string) {
    console.error('PizzaService: ' + message);
  }
}
