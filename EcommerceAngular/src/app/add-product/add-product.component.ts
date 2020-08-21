import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Product } from '../models/product.model';
import { Category } from '../models/category.model';
import { Seller } from '../models/seller.model';
import { DataService } from '../shared/data.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Inventory } from '../models/inventory.model';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  productForm : FormGroup;
  product : Product = new Product();
  categories : Category[] = [];
  selectedCategory : number;
  base64textString: string;
  img : string;
  cat_ID : number;
  Seller_ID : number;
  seller : Seller[] = [];
  inventory : Inventory = new Inventory();
  p_ID : number;
    
  //Upload Image
  selectFile(event){
      var files = event.target.files;
      var file = files[0];

    if (files && file) {
        var reader = new FileReader();

        reader.onload =this.handleFile.bind(this);

        reader.readAsBinaryString(file);
    }
  }



  handleFile(event) {
     var binaryString = event.target.result;
            this.base64textString= btoa(binaryString);
         
            this.img = btoa(binaryString);
            console.log(this.img);
            this._snackBar.open("Image Uploaded", "Close", {
              duration: 1000,verticalPosition: 'top',horizontalPosition: 'right',panelClass: ['red-snackbar'],});
    }
  


  constructor(private _snackBar: MatSnackBar,private dataservice:DataService, private form: FormBuilder, private router: Router) { }



  ngOnInit(): void {
    this.dataservice.getCategoriesList().subscribe (
      result =>  { this.categories = result; console.log(this.categories); },
      error =>  console.log(error));
      this.dataservice.getSellers().subscribe (
        result =>  { this.seller = result; console.log(this.seller); },
        error =>  console.log(error));

      this.productForm = this.form.group({
        ProductName : ['', Validators.required],
        Brand : ['', Validators.required],
        Color : [''],
        Variance : [''],
        Description : [''],
        ReorderQuantity : 0,
        Category_ID :0,
        Seller_ID : 0,
        Stock : 0,
        Price : 0,
    });
  }

  onSubmit() {
    if (this.productForm.valid) {
      this.updateProductValues();
      // tslint:disable-next-line:prefer-const
      this.dataservice.postProduct(this.product).subscribe (
        result =>  {console.log(result); },
        error =>  {console.log(error)});

        this.dataservice.getProdID().subscribe (
          result =>  {this.p_ID = result.Product_ID;
            console.log(result); 
            this.updateInventoryValues();},
          error =>  {console.log(error)});

        
       
      this._snackBar.open("Product Added", "Close", {
      duration: 1000,verticalPosition: 'top',horizontalPosition: 'right',panelClass: ['red-snackbar'],});
     
    } 
    
    else {
      alert("invalid"); 
    }
  }


  updateProductValues() {
    this.product.ProductName = this.productForm.get('ProductName').value;
    this.product.Brand = this.productForm.get('Brand').value;
    if(this.productForm.get('Color').value){
      this.product.Color = this.productForm.get('Color').value;
    }
    if(this.productForm.get('Variance').value){
      this.product.Variance = this.productForm.get('Variance').value;
    }
    if(this.productForm.get('Description').value){
      this.product.Description = this.productForm.get('Description').value;
    }
    this.product.ReorderQuantity = this.productForm.get('ReorderQuantity').value;
    this.product.Category_ID = this.cat_ID;
    this.product.IsDeleted = false;
    this.product.Image = this.img;
  }

  updateInventoryValues()
  {
    this.inventory.Product_ID = this.p_ID;
    this.inventory.Seller_ID = this.Seller_ID;
    this.inventory.Stock = this.productForm.get('Stock').value;
    this.inventory.Price = this.productForm.get('Price').value;

    this.dataservice.postInventory(this.inventory).subscribe (
      result =>  {console.log(result); },
      error =>  {console.log(error)});
      this.productForm.reset();

  }
}
