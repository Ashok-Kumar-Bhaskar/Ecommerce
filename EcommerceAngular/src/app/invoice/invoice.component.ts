import { Component, OnInit } from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { Orderid } from '../models/orderid.model';
import { Invoiceitems } from '../models/invoiceitems.model';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { FormBuilder } from '@angular/forms';
import { DataService } from '../shared/data.service';
import { Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';


@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css'],
})
export class InvoiceComponent implements OnInit {

    userid : number;
    
    orderlist : Invoiceitems[] =[];

    dataSource = this.orderlist;
    displayedColumns = ['Date', 'Orders_ID', 'Product', 'Quantity', 'Amount', 'DeliveryDate'];
  
    constructor(private httpService: HttpClient,public jwtHelper: JwtHelperService, fb: FormBuilder, private dataservice : DataService, private router:Router) {}

  ngOnInit(): void {
    this.userid = JSON.parse(localStorage.getItem("userid"));
    this.dataservice.getOrdersList(this.userid).subscribe (
      result =>  {this.dataSource =result; console.log(result); },
      error =>  console.log(error));

    // this.dataservice.getCategoriesList().subscribe (
    //   result =>  { this.categories = result; console.log(this.categories); },
    //   error =>  console.log(error)
    // );
  }


}
