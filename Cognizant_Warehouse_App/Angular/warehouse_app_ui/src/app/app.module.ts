import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WarehouseComponent } from './warehouse/warehouse.component';
import { VehicleDetailComponent } from './warehouse/vehicle-detail/vehicle-detail.component';
import { WarehouseService } from './shared/warehouse.service';
import { ModalModule, BsModalService } from 'ngx-bootstrap/modal';

import{HttpClientModule} from '@angular/common/http';
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
    ReactiveFormsModule,
    ModalModule
  ],
  providers: [WarehouseService,BsModalService],
  bootstrap: [AppComponent]
})
export class AppModule { }
