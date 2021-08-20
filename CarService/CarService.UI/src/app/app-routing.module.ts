import { RepairOrdersListComponent } from './repairOrdersList/repairOrdersList.component';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateOrderFormComponent } from './createOrderForm/createOrderForm.component';
import { AddCarFormComponent } from './addCarForm/addCarForm.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'orders', component: RepairOrdersListComponent},
  {path: 'createOrder', component: CreateOrderFormComponent},
  {path: 'addCar', component: AddCarFormComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
