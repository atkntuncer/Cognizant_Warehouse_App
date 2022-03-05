import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { IWarehouse } from '../shared/warehouse.model';
import { WarehouseService } from '../shared/warehouse.service';
import { BsModalService } from 'ngx-bootstrap/modal';

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

  vehicleDetail(vehicle:IWarehouse){
    this.vehicle=vehicle
    this.ActivateComponent=true;
  }

  closeClick(){
this.ActivateComponent=false;
  }
}
