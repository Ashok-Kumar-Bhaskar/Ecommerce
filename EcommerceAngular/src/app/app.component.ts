import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Product } from './models/product.model';
import { DataService } from './shared/data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'EcommerceAngular';
  products : Product[] = []; 
  p: Product[]  = [];
  constructor(public router: Router, private activatedRoute: ActivatedRoute,private dataservice : DataService) {}

  ngOnInit(): void {
    this.dataservice.getProductsList().subscribe (
      res =>  { this.products = res;
        console.log(this.products);
      this.p=this.products;},
      error =>  console.log(error));
  }
}
