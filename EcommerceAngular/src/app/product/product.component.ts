import { Component, OnInit } from '@angular/core';
import { PartiallyEmittedExpression } from 'typescript';
import { Product } from '../models/product.model';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { User } from '../models/user.model';
import { Item } from '../models/item.model';
import { DataService } from '../shared/data.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  displayedColumns: string[] = ['property'];
  expire : boolean;
  product : Product ;
  user : User;
  item : Item;

//   doSomething(event){
//     this.product.Quantity = event;  // input value is logged
//  }

 constructor() { }

 ngOnInit(): void {
   this.product = JSON.parse(localStorage.getItem("product"));

   document.getElementById("img").innerHTML = "<img src='data:image/jpg;base64," + this.product.Image + "'" + " style='height:100%'>" ;

  }
}