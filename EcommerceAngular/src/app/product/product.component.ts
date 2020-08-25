import { Component, OnInit } from '@angular/core';
import { PartiallyEmittedExpression } from 'typescript';
import { Product } from '../models/product.model';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { User } from '../models/user.model';
import { Item } from '../models/item.model';
import { DataService } from '../shared/data.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  displayedColumns: string[] = ['property'];
  expire : boolean;
  product : Product ;
  user : User = new User();
  item : Item = new Item();
  cartid : number;
  flag: any;
  com_ID : any[] = [];

//   doSomething(event){
//     this.product.Quantity = event;  // input value is logged
//  }

qtychange(newValue) {
  this.product.Quantity = newValue;
  console.log(this.product.Quantity);
} 

 constructor(private _snackBar: MatSnackBar,public jwtHelper: JwtHelperService, private router:Router,private dataservice:DataService) { }

 ngOnInit(): void {
  const token=localStorage.getItem('token');
  const admin=localStorage.getItem('isAdmin');
  const expire = this.jwtHelper.isTokenExpired(token);
  if(token==null || expire || admin==='1')
  {
    this.router.navigate(['/signin']);
  }

   this.product = JSON.parse(localStorage.getItem("product"));

   document.getElementById("img").innerHTML = "<img src='data:image/jpg;base64," + this.product.Image + "'" + " style='height:100%'>" ;

   this.user =  JSON.parse(localStorage.getItem("user"));
   console.log(this.user);
   this.cartid = this.user[0].Cart_ID;
   console.log(this.cartid);
 

  }

  checkQuantity()
  {
    if(!this.product.Quantity || this.product.Quantity <=0)
    {
      this._snackBar.open("Please enter Quantity", "Close", {
        duration: 2000,verticalPosition: 'top',horizontalPosition: 'right',panelClass: ['red-snackbar'],});
    }
    else if(this.product.Quantity>this.product.Stock)
    {
      this._snackBar.open("Stock Not Available", "Close", {
        duration: 2000,verticalPosition: 'top',horizontalPosition: 'right',panelClass: ['red-snackbar'],});
    }
    else{
      this.addToItems();
    }
  }

  addToItems()
  {
    this.cartid = this.user[0].Cart_ID;
    console.log(this.cartid);
    this.dataservice.GetCartCommodityID(this.cartid,this.product.Commodity_ID).subscribe (
      res =>  { this.flag = res;
        console.log(this.flag);
        this.addToCart();},
      error =>  console.log(error));

     
  }

  addToCart(){
    console.log(this.user.Cart_ID);
    console.log(this.product);
    console.log(this.item);
    if(this.flag === 0)
    {
      this.dataservice.putItems(this.cartid,this.product.Commodity_ID,this.product.Quantity).subscribe (
        res =>  { this.com_ID = res;
          console.log(this.com_ID);
        this._snackBar.open("Added To Cart", "Close", {
          duration: 2000,verticalPosition: 'top',horizontalPosition: 'right',panelClass: ['red-snackbar'],});},
        error =>  console.log(error));
    }
    else{
    this.item.Cart_ID = this.user[0].Cart_ID;
    this.item.Commodity_ID = this.product.Commodity_ID;
    this.item.Quantity = this.product.Quantity;
    this.item.Amount = this.product.Quantity * this.product.Price;

    console.log(this.item);
    this.dataservice.postItems(this.item).subscribe (
      res =>  { console.log(res);
        this._snackBar.open("Added To Cart", "Close", {
          duration: 2000,verticalPosition: 'top',horizontalPosition: 'right',panelClass: ['red-snackbar'],});
      },error =>  console.log(error));
    }

    this.dataservice.PutStock(this.product.Commodity_ID,this.product.Quantity).subscribe (
      res => {console.log(res);},
      error =>  console.log(error));
  }

  homePage()
  {
    this.router.navigate(['/home']);
  }
}

