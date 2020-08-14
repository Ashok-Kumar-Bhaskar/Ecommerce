// import { Component, OnInit, ɵclearResolutionOfComponentResourcesQueue } from '@angular/core';
// import { FormBuilder, FormGroup } from '@angular/forms';
// import { Category } from '../models/category.model'
// import { DataService } from '../shared/data.service';
// import { Product } from '../models/product.model';
// import { HttpClient } from '@angular/common/http';
// import { Router } from "@angular/router";

// @Component({
//   selector: 'app-category',
//   templateUrl: './category.component.html',
//   styleUrls: ['./category.component.css']
// })
// export class CategoryComponent implements OnInit {
//   options: FormGroup;
//   categories : Category[] = [];

//   products : Product[] = [];

//   p : Product[] =[];

//   pList : string[] = [];
  
//   category : Category;
  

//   constructor(private httpService: HttpClient, fb: FormBuilder, private dataservice : DataService, private router:Router) {
//     this.options = fb.group({
//       bottom: 0,
//       fixed: false,
//       top: 0
//     });
//   }

//   ngOnInit(): void {
//     this.category = JSON.parse(localStorage.getItem("category"));
//     console.log(this.category);
//       this.getCategories();
//       this.getProductsByCategory(this.category);
//   }

//  getCategories()
//   {
//       this.dataservice.getCategoriesList().subscribe (
//           result =>  { this.categories = result; console.log(this.categories); },
//           error =>  console.log(error)
//     );
//   }

//   getProductsByCategory(category)
//   {
    
//     this.dataservice.getProductsListByCategory(category).subscribe (
//       res =>  { this.products = res;
//         console.log(this.products);
//         this.p=this.products;},
//       error =>  console.log(error));

   
//   }
  
//   getpdts(cat)
//   {
//     console.log(this.products)
//     this.pList = [];
//     this.products.forEach(element => {
//       if(element.Category_ID == cat.Category_ID && !this.pList.includes(element.ProductName))
//         this.pList.push(element.ProductName);
//       });
//   }

//   getP()
//   {
//     console.log(this.products);
//     this.p = this.products;
//     console.log(this.p);
//   }

//   goToProduct(id)
//   {
//     console.log(id);
//     localStorage.setItem("product",JSON.stringify(id));
//     this.router.navigate(["/product"]);
//   }

// }
