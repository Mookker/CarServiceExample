import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { emptyGuild } from '../helpers/emptyGuid';
import { CarOwner } from '../models/carOwner';
import { CarService } from '../services/car.service';

@Component({
  selector: 'app-addOwnerForm',
  templateUrl: './addOwnerForm.component.html',
  styleUrls: ['./addOwnerForm.component.css']
})
export class AddOwnerFormComponent implements OnInit {

  constructor(
    private carService: CarService,
    private confirmService: ConfirmationService,
    private messageService: MessageService
  ) { }

  firstName!: string;
  lastName!: string;
  doB!: Date

  maxDate: Date = new Date('2003-01-01');

  ngOnInit() {
  }

  handleAddButtonClick() {
    const carOwner: CarOwner = {
      firstName: this.firstName,
      lastName: this.lastName,
      doB: this.doB,
      carId: emptyGuild
    };

    this.confirmService.confirm({
      message: `Are you sure to add ${this.firstName} ${this.lastName} as Car Owner ?`,
      accept: () => {
        this.carService.createCarOwner(carOwner);
        this.messageService.add({severity: 'success', summary: 'Success', detail: "Car Owner successfully added"})
      }
    });
  }
}
