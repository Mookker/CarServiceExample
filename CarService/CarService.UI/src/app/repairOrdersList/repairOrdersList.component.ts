import { Car } from './../models/car';
import { CarService } from './../services/car.service';
import { Component, OnChanges, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { RepairOrder } from '../models/repairOrder';

@Component({
  selector: 'app-repairOrdersList',
  templateUrl: './repairOrdersList.component.html',
  styleUrls: ['./repairOrdersList.component.css']
})
export class RepairOrdersListComponent implements OnInit, OnChanges {
  repairOrders: RepairOrder[] = [];
  isLoading: boolean = true;

  constructor(private carService: CarService) { }

  async ngOnInit() {
    this.repairOrders = await this.carService.getRepairOrders();
    this.isLoading = false;
  }

  async ngOnChanges() {
    this.repairOrders = await this.carService.getRepairOrders();
    this.isLoading = false;
  }

  doneRepirOrderClickHandler(repairOrder: RepairOrder) {
    this.repairOrders = this.repairOrders.filter(order => order != repairOrder);
    this.carService.deleteRepairOrder(repairOrder);
  }
}
