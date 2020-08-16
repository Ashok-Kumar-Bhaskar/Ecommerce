import { Component, OnInit, ɵclearResolutionOfComponentResourcesQueue } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Category } from '../models/category.model'
import { DataService } from '../shared/data.service';
import { Product } from '../models/product.model';
import { HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from '../models/user.model';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})



export class HomeComponent implements OnInit {
  
  options: FormGroup;
  categories : Category[] = [];

  products : Product[] = [];

  p : Product[] =[];

  pList : string[] = [];
  

  expire: Boolean;


  constructor(private httpService: HttpClient,public jwtHelper: JwtHelperService, fb: FormBuilder, private dataservice : DataService, private router:Router) {}

  ngOnInit(): void {
    const token=localStorage.getItem('token');
    this.expire = this.jwtHelper.isTokenExpired(token);
    if(token==null || this.expire ){
      this.router.navigate(['/signin']);
    }
      this.getCategories();
      this.getProducts();
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
      this.p=this.products;},
      error =>  console.log(error));
  }
  
  getpdts(cat)
  {
    localStorage.setItem("category",JSON.stringify(cat));
    this.router.navigate(['/category']);
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


}
