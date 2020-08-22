import { Component, OnInit, ɵclearResolutionOfComponentResourcesQueue } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Category } from '../models/category.model'
import { DataService } from '../shared/data.service';
import { Product } from '../models/product.model';
import { HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";
import { JwtHelperService } from '@auth0/angular-jwt';
import { Item } from '../models/item.model';
import { User } from '../models/user.model';
import { UiService } from '../shared/ui.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  options: FormGroup;
  categories : Category[] = [];

  products : Product[] = [];

  p : Product[] =[];

  productOfCategory : Product[] = [];

  expire : boolean;
  cartid : number;
  item : Item = new Item();
  user : User;
  pList : string[] = [];
  
  category : Category;
  flag: any;
  com_ID : any[] = [];
  

  constructor(private _snackBar: MatSnackBar,private ui : UiService,private httpService: HttpClient,public jwtHelper: JwtHelperService, fb: FormBuilder, private dataservice : DataService, private router:Router) {
    this.ui.spin$.next(true);
  }

  ngOnInit(): void {
    const token=localStorage.getItem('token');
    this.expire = this.jwtHelper.isTokenExpired(token);
    if(token==null || this.expire ){
      this.router.navigate(['/signin']);
    }
    this.getProducts();
    this.getCategories();

    this.category = JSON.parse(localStorage.getItem("category"));
    
    console.log(this.category);

      this.getProductsInCategory(this.category.Category_ID);
      this.user =  JSON.parse(localStorage.getItem("user"));
      this.cartid = this.user[0].Cart_ID;
      
  }

 getCategories()
  {
      this.dataservice.getCategoriesList().subscribe (
          result =>  { this.categories = result; console.log(this.categories); },
          error =>  console.log(error)
    );
  }

  getProducts()
  {
        this.dataservice.getProductsList().subscribe (
        res =>  { this.products = res;
          console.log(this.products);
        this.p=this.products;
        },
        error =>  {console.log(error);this.ui.spin$.next(false);});
        
        
        
  }
  
  getProductsInCategory(id)
  {
    this.dataservice.getProductsListByCategory(id).subscribe(res => {
        this.productOfCategory = res;this.ui.spin$.next(false);},
        err => {console.log(err);this.ui.spin$.next(false);});
  }

  getpdts(cat)
  {
    localStorage.setItem("category",JSON.stringify(cat));
    window.location.reload();
  }

  getP()
  {
    console.log(this.products);
    this.p = this.products;
    console.log(this.p);
  }

  goToProduct(id)
  {
    console.log(id);
    localStorage.setItem("product",JSON.stringify(id));
    this.router.navigate(["/product"]);
  }

  addToItems(ps)
  {
    this.cartid = this.user[0].Cart_ID;
    console.log(this.cartid);
    this.dataservice.GetCartCommodityID(this.cartid,ps.Commodity_ID).subscribe (
      res =>  { this.flag = res;
        console.log(this.flag);
        this.addToCart(ps);},
      error =>  console.log(error));

     
  }

  addToCart(ps)
  {
    console.log(this.flag);
    if(this.flag === 0)
    {
      this.dataservice.putItems(this.cartid,ps.Commodity_ID,1).subscribe (
        res =>  { this.com_ID = res;
          console.log(this.com_ID);
        this._snackBar.open("Added To Cart", "Close", {
          duration: 2000,verticalPosition: 'top',horizontalPosition: 'right',panelClass: ['red-snackbar'],});},
        error =>  console.log(error));
    }
    else{
    this.item.Cart_ID = this.user[0].Cart_ID;
    this.item.Commodity_ID = ps.Commodity_ID;
    this.item.Quantity = 1;
    this.item.Amount = ps.Price;

    console.log(this.item);
    this.dataservice.postItems(this.item).subscribe (
      res => {console.log(res); 
        this._snackBar.open("Added To Cart", "Close", {
          duration: 2000,verticalPosition: 'top',horizontalPosition: 'right',panelClass: ['red-snackbar'],});
        },error =>  console.log(error));
    }

    this.dataservice.PutStock(ps.Commodity_ID,1).subscribe (
      res => {console.log(res);},
      error =>  console.log(error));
  }

}
