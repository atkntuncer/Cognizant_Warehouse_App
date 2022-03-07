import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { VehicleDetailComponent } from './vehicle-detail.component';
import { HttpClient, HttpErrorResponse } from '@angular/common/http'; 

describe('VehicleDetailComponent', () => {
  let component: VehicleDetailComponent;
  let fixture: ComponentFixture<VehicleDetailComponent>;
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VehicleDetailComponent ],
      imports: [ HttpClientTestingModule ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleDetailComponent);
    component = fixture.componentInstance;
    component.vehicle={
      id:0,
      warehouseName:"",
      location:"",
      make:"",
      model:"",
      price:0,
      year_Model:0,
      licensed:1,
  added_Date:""
    };
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
