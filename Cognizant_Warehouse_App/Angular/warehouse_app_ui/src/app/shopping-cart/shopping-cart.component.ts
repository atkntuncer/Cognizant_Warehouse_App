import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IWarehouse } from '../shared/warehouse.model';
import { WarehouseService } from '../shared/warehouse.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  private subs: Subscription; 
   totalPrice:number=0; 

   //subscribe to sender component messages
  constructor(private service:WarehouseService) { 
this.subs=service.getUpdate().subscribe(message=>{
  this.ngOnInit();
})
  }

cartList:IWarehouse[];
  ngOnInit(): void {
    this.getShoppingCart();
  }

  //get vehicle list from cart
  getShoppingCart(){
    this.totalPrice=0;
    this.service.getShoppingCartList().subscribe(result=>{
      this.cartList=result;
      result.forEach(element => {
        this.totalPrice+=element.price;
      });
    });
  }

  //delete vehicle from cart
  deleteVehicle(vehicle:IWarehouse){
this.service.deleteFromCart(vehicle).subscribe(result=>{
  this.ngOnInit();
})
  }

  ngOnDestroy() { 
    this.subs.unsubscribe();
}
}
