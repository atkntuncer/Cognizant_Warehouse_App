import { IWarehouse } from "./warehouse.model";

export class Vehicle implements IWarehouse {
    id: number=0;
    warehouseName: string='';
    location: string='';
    make: string='';
    model: string='';
    year_Model: number=0;
    price: number=0;
    licensed: number=0;
    added_Date: string='';
}
