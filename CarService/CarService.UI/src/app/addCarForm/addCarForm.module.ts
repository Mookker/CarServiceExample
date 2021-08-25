import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddCarFormComponent } from './addCarForm.component';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { DropdownModule } from 'primeng/dropdown';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';



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
    ToastModule
  ],
  declarations: [AddCarFormComponent]
})
export class AddCarFormModule { }
