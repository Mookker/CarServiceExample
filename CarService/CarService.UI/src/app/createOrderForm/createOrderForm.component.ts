import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Car } from '../models/car';
import { CreateRepairOrder } from '../queries/createRepairOrder';
import { CarService } from '../services/car.service';

@Component({
  selector: 'app-createOrderForm',
  templateUrl: './createOrderForm.component.html',
  styleUrls: ['./createOrderForm.component.css']
})
export class CreateOrderFormComponent implements OnInit {

  constructor(
    private carService: CarService, 
    private confirmationService: ConfirmationService,
    private messageService: MessageService) { }

  cars: Car[] = [];
  carsInfo: any[] = [];
  selectedCar: any;

  repairOrderPrice: number = 0;

  async ngOnInit() {
    this.cars = await this.carService.getCars();
    
    for (let car of this.cars) {
      this.carsInfo.push({info: `${car.make} ${car.model} ${car.year} VIN: ${car.vin}`, car: car});
    }
  }

  handleCreateClick() {
    this.confirmationService.confirm({
      message: `Are you sure you want to create repair order on ${this.selectedCar.info} ?`,
      accept: () => {
        const repairOrder: CreateRepairOrder = {
          price: this.repairOrderPrice,
          orderDate: new Date(),
          carId: this.selectedCar.car.id
        }

        this.carService.createRepairOrder(repairOrder);
        this.messageService.add({severity: 'success', summary: 'Success', detail: 'Repair Order successfully added'});
      }
    });
  }
}
