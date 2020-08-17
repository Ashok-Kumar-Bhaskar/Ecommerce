import { Component, OnInit } from '@angular/core';
import { Address } from '../models/address.model';
import { Cart } from '../models/cart.model';
import { FormBuilder } from '@angular/forms';
import { JwtHelperService } from '@auth0/angular-jwt';
import { DataService } from '../shared/data.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user.model';
import { PaymentMode } from '../models/paymentmode.model';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  address : Address[] =[];
  cart : Cart[] =[];
  user : User;
  selectedAddr : Address;
  GrandTotal : any;
  selectedMOP : number;

  PaymentMethods : PaymentMode[] = [{"PaymentMode_ID" : 742001, "Mode" : "Credit Card"},
                                    {"PaymentMode_ID" : 742002, "Mode" : "Debit Card"},
                                    {"PaymentMode_ID" : 742003, "Mode" : "COD"},
                                    {"PaymentMode_ID" : 742004, "Mode" : "Net Banking"},]

  constructor(private httpService: HttpClient,public jwtHelper: JwtHelperService, fb: FormBuilder, private dataservice : DataService, private router:Router) { }

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem("user"));
    this.getAddress(this.user[0].User_ID);
    this.getCart(this.user[0].Username);
    // this.getAddressid();
    this.GrandTotal = localStorage.getItem("cartTotalValue");
  }

  getAddress(id)
  {
  this.dataservice.getAddresses(id).subscribe (
    result =>  { this.address = result; console.log(this.address); },
    error =>  console.log(error)
    );
  }

  getCart(name)
  {
    this.dataservice.getCartItems(name).subscribe (
      result =>  { this.cart = result; console.log(this.cart); },
      error =>  console.log(error)
      );
  }

  getAddressid(a)
  {
    console.log(a);
    this.selectedAddr = a;
    console.log(this.selectedAddr.Address_ID);  
    localStorage.setItem("Address",JSON.stringify(this.selectedAddr));
  }

  getPaymentID(m)
  {
    console.log(m);
    this.selectedMOP = m;
    console.log(this.selectedMOP);  
    localStorage.setItem("PaymentMode",JSON.stringify(this.selectedMOP));
  }
}
