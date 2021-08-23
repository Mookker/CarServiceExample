import { GetAllCars } from './../queries/getAllCars';
import { Injectable } from '@angular/core';
import { Apollo } from 'apollo-angular';
import { createCarMutation, createCarOwnerMutation, createRepairOrderMutation, deleteRepairOrderMutation, getCarOwnersQuery, getCarsQuery, getRepairOrdersQuery } from '../queries/queries';
import { GetAllRepairOrders } from '../queries/getAllRepairOrders';
import { RepairOrder } from '../models/repairOrder';
import { CreateRepairOrder } from '../queries/createRepairOrder';
import { GetAllCarOwners } from '../queries/getAllCarOwners';
import { Car } from '../models/car';
import { CarOwner } from '../models/carOwner';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  constructor(private apollo: Apollo) {}

  getCars() {
    return this.apollo.watchQuery<GetAllCars>({
      query: getCarsQuery
    })
    .result().then(result => {return result.data.cars});
  }

  getRepairOrders() {
    return this.apollo.watchQuery<GetAllRepairOrders>({
      query: getRepairOrdersQuery
    })
    .result().then(result => {return result.data.repairOrders});
  }

  createRepairOrder(repairOrder: CreateRepairOrder) {
    return this.apollo.mutate({
      mutation: createRepairOrderMutation,
      variables: { repairOrder }
    })
    .subscribe();
  }

  createCar(car: Car) {
    return this.apollo.mutate({
      mutation: createCarMutation,
      variables: { car }
    })
    .subscribe();
  }

  createCarOwner(carOwner: CarOwner) {
    return this.apollo.mutate({
      mutation: createCarOwnerMutation,
      variables: { carOwner }
    })
    .subscribe();
  }

  deleteRepairOrder(repairOrder: RepairOrder) {
    return this.apollo.mutate({
      mutation: deleteRepairOrderMutation,
      variables: { id: repairOrder.id }
    })
    .subscribe();
  }

  getAllCarOwners() {
    return this.apollo.watchQuery<GetAllCarOwners>({
      query: getCarOwnersQuery
    })
    .result().then(result => {return result.data.carOwners});
  }
}
