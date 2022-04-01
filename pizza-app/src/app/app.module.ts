import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { HttpClientInMemoryWebApiModule } from "angular-in-memory-web-api";
import { InMemoryDataService } from "./in-memory-data.service.service";
import { AppRoutingModule } from "./app-routing.module";
import {
  MatSliderModule,
  MatSidenavModule,
  MatSelectModule,
  MatButtonToggleModule,
  MatCardModule,
  MatButtonModule,
  MatGridListModule,
  MatMenuModule,
  MatToolbarModule,
} from "@angular/material";

import { AppComponent } from "./app.component";
import { PizzaMainLayoutComponent } from "./pizza-main-layout/pizza-main-layout.component";
import { PizzaDetailComponent } from "./pizza-detail/pizza-detail.component";
import { PizzaHeaderComponent } from "./pizza-header/pizza-header.component";
import { PizzaCartComponent } from "./pizza-cart/pizza-cart.component";

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    MatSliderModule,
    MatSidenavModule,
    MatSelectModule,
    MatButtonToggleModule,
    MatCardModule,
    MatButtonModule,
    MatGridListModule,
    MatMenuModule,
    MatToolbarModule,
    BrowserAnimationsModule,
    HttpClientModule,
    // HttpClientInMemoryWebApiModule.forRoot(
    //   InMemoryDataService, { dataEncapsulation: false }
    // )
  ],
  declarations: [
    AppComponent,
    PizzaMainLayoutComponent,
    PizzaDetailComponent,
    PizzaHeaderComponent,
    PizzaCartComponent,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
