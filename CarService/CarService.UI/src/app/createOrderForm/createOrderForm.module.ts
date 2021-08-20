import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateOrderFormComponent } from './createOrderForm.component';

import {InputTextModule} from 'primeng/inputtext';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {DropdownModule} from 'primeng/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CardModule } from 'primeng/card';
import {InputNumberModule} from 'primeng/inputnumber';
import { ButtonModule } from 'primeng/button';
import {ConfirmDialogModule} from 'primeng/confirmdialog';
import { ToastModule } from 'primeng/toast'

@NgModule({
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    InputTextModule,
    FormsModule,
    DropdownModule,
    CardModule,
    InputNumberModule,
    ButtonModule,
    ConfirmDialogModule,
    ReactiveFormsModule,
    ToastModule
  ],
  declarations: [CreateOrderFormComponent]
})
export class CreateOrderFormModule { }
