import { RepairOrdersListModule } from './repairOrdersList/repairOrdersList.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HeaderModule } from './header/header.module';
import { GraphQLModule } from './graphql.module';
import { HttpClientModule, HttpHeaders } from '@angular/common/http';

import { APOLLO_OPTIONS } from 'apollo-angular';
import {HttpLink} from 'apollo-angular/http';
import {InMemoryCache} from '@apollo/client/core';
import { CommonModule } from '@angular/common';
import { CreateOrderFormModule } from './createOrderForm/createOrderForm.module';
import { ConfirmationService, MessageService } from 'primeng/api';
import { AddCarFormModule } from './addCarForm/addCarForm.module';
import { AddOwnerFormModule } from './addOwnerForm/addOwnerForm.module';


@NgModule({
  declarations: [		
    AppComponent,
      HomeComponent,
   ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HeaderModule,
    CreateOrderFormModule,
    RepairOrdersListModule,
    AddCarFormModule,
    AddOwnerFormModule,
    GraphQLModule,
    HttpClientModule,
  ],
  providers: [
    {
      provide: APOLLO_OPTIONS,
      useFactory: (httpLink: HttpLink) => {
        return {
          cache: new InMemoryCache(),
          link: httpLink.create({
            uri: 'http://localhost:5001/graphql',
            withCredentials: false,
            headers: new HttpHeaders().set('Access-Control-Allow-Origin', '*')
          }),
        };
      },
      deps: [HttpLink],
    },
    ConfirmationService,
    MessageService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
