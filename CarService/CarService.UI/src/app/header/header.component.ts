import { Component, OnInit } from '@angular/core';

import {MenuItem} from 'primeng/api';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  items: MenuItem[];

  constructor() {
    this.items = [
      {label: 'Home', icon: 'pi pi-fw pi-home', routerLink: ['/']},
      {label: 'Repair Orders', icon: 'pi pi-fw pi-table', routerLink: ['/orders']},
      {label: 'Create an Order', icon: 'pi pi-fw pi-shopping-cart', routerLink: ['/createOrder']},
      {label: 'Add a Car', icon: 'pi pi-fw pi-plus', routerLink: ['/addCar']}
    ];
   }

  ngOnInit() {
  }

}
