import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { range } from 'rxjs';
import { toArray } from 'rxjs/operators';
import { carBrands } from '../helpers/carBrandsList';
import { Car } from '../models/car';
import { CarService } from '../services/car.service';

@Component({
  selector: 'app-addCarForm',
  templateUrl: './addCarForm.component.html',
  styleUrls: ['./addCarForm.component.css']
})
export class AddCarFormComponent implements OnInit {

  carBarndSuggestions: string[] = carBrands;

  carBrand: string = '';
  carModel: string = '';
  carYear: number = 2021;
  carVin: string = '';
  carMillage: number = 0;
  carOwnerId: string = '';

  years: number[] = [];
  carOwnersInfo: any[] = [];
  
  constructor(
    private carService: CarService, 
    private confirmService: ConfirmationService,
    private messageService: MessageService) { }

  async ngOnInit() {
    range(1900, 122).pipe(toArray()).subscribe(years => this.years = years);

    const carOwners =  await this.carService.getAllCarOwners();
    carOwners.forEach(owner => {
      this.carOwnersInfo.push(
        {info: `${owner.firstName} ${owner.lastName} ${new Date(owner.doB).getFullYear()} year`, owner: owner});
    });
  }

  handleAddCarClick() {
    const car: Car = {
      make: this.carBrand,
      model: this.carModel,
      year: this.carYear,
      vin: this.carVin,
      millage: this.carMillage,
      ownerId: this.carOwnerId,
    };
    
    this.confirmService.confirm({
      message: 'Are you sure to add this Car ?',
      accept: () => {
        this.carService.createCar(car);
        this.messageService.add({severity:'success', summary: 'Success', detail: 'Car successfully added'});
      }
    });
  }
}
