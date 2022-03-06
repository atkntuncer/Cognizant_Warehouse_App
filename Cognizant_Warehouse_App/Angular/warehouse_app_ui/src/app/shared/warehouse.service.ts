import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { IWarehouse } from './warehouse.model';

@Injectable({
  providedIn: 'root'
})
export class WarehouseService {
readonly url:string='http://localhost:5000/api';
private subjectName = new Subject<any>();//for re initialize the shopping cart component
  constructor(private http:HttpClient) { }

  getVehicleList():Observable<IWarehouse[]>{
    return this.http.get<IWarehouse[]>(this.url+"/vehicle/list");
  }

  getShoppingCartList():Observable<IWarehouse[]>{
    return this.http.get<IWarehouse[]>(this.url+"/ShoppingCart/list");
  }

  addtoCart(vehicle:IWarehouse){
    return this.http.post(this.url+"/ShoppingCart/Create",vehicle);
  }

  deleteFromCart(vehicle:IWarehouse){
    return this.http.post(this.url+"/ShoppingCart/delete",vehicle);
  }
  
  //send message to subject
  sendUpdate(message: string) { 
     this.subjectName.next({ text: message }); 
  }
   
  //get message from subject
   getUpdate(): Observable<any> { 
     return this.subjectName.asObservable(); 
   }
}
