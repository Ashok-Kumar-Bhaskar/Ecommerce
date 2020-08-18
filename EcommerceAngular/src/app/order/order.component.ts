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
import { Order } from '../models/order.model';
import { Shipment } from '../models/shipment.model';

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
  selectedMOP : PaymentMode;
  order : Order = new Order();
  shippingAgent : Shipment;
  shipment : Shipment[] = [{"Shipment_ID" : 100001, "AgentName" : "BlueDart"},
                           {"Shipment_ID" : 100002, "AgentName" : "Delhivery"},
                           {"Shipment_ID" : 110003, "AgentName" : "DHL"},
                           {"Shipment_ID" : 110004, "AgentName" : "Professional"}];

  PaymentMethods : PaymentMode[] = [{"PaymentMode_ID" : 742001, "Mode" : "Credit Card"},
                                    {"PaymentMode_ID" : 742002, "Mode" : "Debit Card"},
                                    {"PaymentMode_ID" : 752003, "Mode" : "COD"},
                                    {"PaymentMode_ID" : 752004, "Mode" : "Net Banking"},]

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
    this.shipmentAgent();
  }

  shipmentAgent()
  {
    if(100000<this.selectedAddr.Pincode && this.selectedAddr.Pincode<=250000)
    {
      this.shippingAgent = this.shipment[0];
    }
    else if(250000<this.selectedAddr.Pincode && this.selectedAddr.Pincode<=500000)
    {
      this.shippingAgent = this.shipment[1];
    }
    else if(500000<this.selectedAddr.Pincode && this.selectedAddr.Pincode<=750000)
    {
      this.shippingAgent = this.shipment[2];
    }    
    else if(750000<this.selectedAddr.Pincode && this.selectedAddr.Pincode<=999999)
    {
      this.shippingAgent = this.shipment[3];
    }
    else{
      console.log("Invalid Pincode");
    }
  }

  getPaymentID(m)
  {
    console.log(m);
    this.selectedMOP = m;
    console.log(this.selectedMOP);  
    localStorage.setItem("PaymentMode",JSON.stringify(this.selectedMOP));
  }

  ConfirmOrder()
  {
    this.order.Cart_ID = this.user[0].Cart_ID;
    this.order.User_ID = this.user[0].User_ID;
    this.order.Shipment_ID = this.shippingAgent.Shipment_ID;
    this.order.Payment_ID = this.selectedMOP.PaymentMode_ID;
    var date = new Date();
    this.order.Date = date.toDateString();
    var edate = new Date();
    edate.setDate(date.getDate()+3);
    this.order.EstimatedDate = edate.toDateString();
    console.log(this.order.Date);
    console.log(this.order.EstimatedDate);
    this.order.OrdersStatus_Code = 11002;
    console.log(this.order);

    this.dataservice.postOrder(this.order).subscribe (
      result =>  { console.log(result); },
      error =>  console.log(error));

    this.dataservice.postCart(this.user[0].User_ID).subscribe (
      result =>  { console.log(result); },
      error =>  console.log(error));

    this.dataservice.putCart(this.user[0].Cart_ID).subscribe (
      result =>  { console.log(result); },
      error =>  console.log(error));

     
  }
}
