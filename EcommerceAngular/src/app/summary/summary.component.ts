import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../shared/data.service';
import { FormBuilder } from '@angular/forms';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import { Address } from '../models/address.model';
import { PaymentMode } from '../models/paymentmode.model';
import { Shipment } from '../models/shipment.model';
import { Cart } from '../models/cart.model';
import { User } from '../models/user.model';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})
export class SummaryComponent implements OnInit {

  
  payment : PaymentMode;
  cart : number;
  user : User;
  total : any;



  constructor(private httpService: HttpClient,public jwtHelper: JwtHelperService, fb: FormBuilder, private dataservice : DataService, private router:Router) { }

  ngOnInit(): void {
    const token=localStorage.getItem('token');
    const admin=localStorage.getItem('isAdmin');
    const expire = this.jwtHelper.isTokenExpired(token);
    if(token==null || expire || admin==='1')
    {
      this.router.navigate(['/signin']);
    }
    // this.address = JSON.parse(localStorage.getItem("Address"));
    this.payment = JSON.parse(localStorage.getItem("PaymentMode"));
    // this.shipmentAgent();
    this.user = JSON.parse(localStorage.getItem("user"));
    this.total = JSON.parse(localStorage.getItem("cartTotalValue"));
    // this.addToOrders();
  }



  // addToOrders()
  // {

  // }
}
