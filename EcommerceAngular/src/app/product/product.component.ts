import { Component, OnInit } from '@angular/core';
import { PartiallyEmittedExpression } from 'typescript';
import { Product } from '../models/product.model';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  displayedColumns: string[] = ['property'];

  product : Product ;
  
  constructor() { }

  ngOnInit(): void {
    this.product = JSON.parse(localStorage.getItem("product"));

    document.getElementById("img").innerHTML = "<img src='data:image/jpg;base64," + this.product.Image + "'" + " style='height:100%'>" ;

    document.getElementById("name").innerText += this.product.Brand + " " + this.product.ProductName ;
    document.getElementById("category").innerHTML += this.product.CategoryName ;
    if(this.product.Variance != null)
    {
      document.getElementById("variance").innerHTML += this.product.Variance ;
    }
    if(this.product.Color != null)
    {
      document.getElementById("color").innerHTML += this.product.Color ;
    }
    if(this.product.Description != null)
    {
      document.getElementById("description").innerHTML += this.product.Description ;
    }   
    document.getElementById("price").innerHTML += "Rs." + this.product.Price ;
    document.getElementById("seller").innerHTML += this.product.SellerName ;
    
  }

}
