import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Pizza } from './pizza';


@Injectable({
  providedIn: 'root'
})
export class PizzaService {
  private pizzaURL = ' http://localhost:5000/api/pizza';

  constructor(private http: HttpClient) { }

  searchPizza(term): Observable<Pizza[]> {
    const options = term ?
      { params: new HttpParams().set('init', term[0]).set('base1', term[1]).set('type', term[2]) } : {};
    return this.http.get<Pizza[]>(this.pizzaURL+"/SearchPizza", options)
      .pipe(
      tap(_ => this.log(`pizza based on search ${term}`)),
      catchError((this.handleError<Pizza[]>('searchPizzas', [])))
      );
  }
  getPizza(id: number): Observable<Pizza> {
    const url = `${this.pizzaURL}/${id}`;
    return this.http.get<Pizza>(url).pipe(
      tap(_ => this.log(`fetched pizza id=${id}`)),
      catchError(this.handleError<Pizza>(`getPizza id=${id}`))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
       console.error(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }
  private log(message: string) {
    //console.error('PizzaService: ' + message);
  }
}