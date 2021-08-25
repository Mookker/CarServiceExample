import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RepairOrdersListComponent } from './repairOrdersList.component';
import {DataViewModule} from 'primeng/dataview';
import {CardModule} from 'primeng/card';
import { ButtonModule } from 'primeng/button';


@NgModule({
  imports: [
    CommonModule,
    DataViewModule,
    CardModule,
    ButtonModule
  ],
  declarations: [RepairOrdersListComponent],
  exports: [
    RepairOrdersListComponent
  ]
})
export class RepairOrdersListModule { }
