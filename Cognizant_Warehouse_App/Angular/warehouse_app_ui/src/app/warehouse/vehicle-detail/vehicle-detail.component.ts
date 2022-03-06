import { Component, Input, OnInit } from '@angular/core';
import { Vehicle } from 'src/app/shared/vehicle.model';
import { IWarehouse } from 'src/app/shared/warehouse.model';
import { WarehouseService } from 'src/app/shared/warehouse.service';
import { WarehouseComponent } from '../warehouse.component';

@Component({
  selector: 'app-vehicle-detail',
  templateUrl: './vehicle-detail.component.html',
  styleUrls: ['./vehicle-detail.component.css']
})
export class VehicleDetailComponent implements OnInit {

  constructor(private service:WarehouseService) { }

@Input() vehicle:IWarehouse;
vehicleDetail:Vehicle=new Vehicle();

  ngOnInit(): void {
    this.vehicleDetail.id=this.vehicle.id;
    this.vehicleDetail.location=this.vehicle.location;
    this.vehicleDetail.added_Date=this.vehicle.added_Date;
    this.vehicleDetail.make=this.vehicle.make;
    this.vehicleDetail.model=this.vehicle.model;
    this.vehicleDetail.price=this.vehicle.price;
    this.vehicleDetail.warehouseName=this.vehicle.warehouseName;
    this.vehicleDetail.year_Model=this.vehicle.year_Model;
  }
  
  //add vehicle to cart
  addtoCart(vehicle:IWarehouse){
    this.service.addtoCart(vehicle).subscribe(result=>{
      this.service.sendUpdate("Cart updated");
    });
  }

}
