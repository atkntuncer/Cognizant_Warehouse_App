import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Warehouse } from './warehouse.model';

@Injectable({
  providedIn: 'root'
})
export class WarehouseService {
readonly url:string='http://localhost:5000/api';

  constructor(private http:HttpClient) { }

  getVehicleList():Observable<Warehouse[]>{
    return this.http.get<Warehouse[]>(this.url+"/vehicle/list");
  }
}
