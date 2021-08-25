import { RepairOrder } from "./repairOrder";

export interface Car {
  id?: string;
  make?: string;
  model?: string;
  year?: number
  vin?: string;
  millage?: number;
  ownerId?: string;
  repairOrders?: RepairOrder[];
}
