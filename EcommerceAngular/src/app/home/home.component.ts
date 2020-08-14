import { Component, OnInit, ɵclearResolutionOfComponentResourcesQueue } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Category } from '../models/category.model'
import { DataService } from '../shared/data.service';
import { Product } from '../models/product.model';
import { HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";


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
  


  constructor(private httpService: HttpClient, fb: FormBuilder, private dataservice : DataService, private router:Router) {
    this.options = fb.group({
      bottom: 0,
      fixed: false,
      top: 0
    });
  }

  ngOnInit(): void {
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
