import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WarehouseComponent } from './warehouse/warehouse.component';
import { VehicleDetailComponent } from './warehouse/vehicle-detail/vehicle-detail.component';
import { WarehouseService } from './shared/warehouse.service';


import{HttpClientModule,HttpClient} from '@angular/common/http';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';

@NgModule({
  declarations: [
    AppComponent,
    WarehouseComponent,
    VehicleDetailComponent,
    ShoppingCartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [WarehouseService,HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
