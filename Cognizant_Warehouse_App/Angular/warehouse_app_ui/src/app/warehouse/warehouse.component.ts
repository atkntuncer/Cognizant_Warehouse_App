import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { IWarehouse } from '../shared/warehouse.model';
import { WarehouseService } from '../shared/warehouse.service';


@Component({
  selector: 'app-warehouse',
  templateUrl: './warehouse.component.html',
  styleUrls: ['./warehouse.component.css']
})
export class WarehouseComponent implements OnInit {

  constructor(private service:WarehouseService ) { }
  @ViewChild('modal')modal:TemplateRef<Object>;
  vehicleList:IWarehouse[];
  vehicle:IWarehouse;
  ActivateComponent:boolean=false;

  ngOnInit(): void {
   this.service.getVehicleList().subscribe(result=>{
     this.vehicleList=result;
   });
  }

  //get all vehicle detail
  vehicleDetail(vehicle:IWarehouse){
    this.vehicle=vehicle
    this.ActivateComponent=true;
  }

  //close modal
  closeClick(){
this.ActivateComponent=false;
  }

  //add vehicle to cart
  addtoCart(vehicle:IWarehouse){
    this.service.addtoCart(vehicle).subscribe(result=>{
      this.service.sendUpdate("Cart updated");
    });
  }
}
