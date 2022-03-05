import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Warehouse } from '../shared/warehouse.model';
import { WarehouseService } from '../shared/warehouse.service';

@Component({
  selector: 'app-warehouse',
  templateUrl: './warehouse.component.html',
  styleUrls: ['./warehouse.component.css']
})
export class WarehouseComponent implements OnInit {

  constructor(private service:WarehouseService) { }
  @ViewChild('modal',{static:true})modal:ElementRef;
  vehicleList:Warehouse[];

  ngOnInit(): void {
   this.service.getVehicleList().subscribe(result=>{
     this.vehicleList=result;
   });
  }

  vehicleDetail(){
this.modal.nativeElement='modal fade show'
  }
}
