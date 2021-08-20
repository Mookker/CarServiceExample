import { Car } from "./car";

export interface RepairOrder {
  id? : string;
  price: number;
  orderDate: Date;
  car: Car
}
