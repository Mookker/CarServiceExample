import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddOwnerFormComponent } from './addOwnerForm.component';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DropdownModule } from 'primeng/dropdown';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';
import {CalendarModule} from 'primeng/calendar';

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
    ToastModule,
    CalendarModule
  ],
  declarations: [AddOwnerFormComponent]
})
export class AddOwnerFormModule { }
