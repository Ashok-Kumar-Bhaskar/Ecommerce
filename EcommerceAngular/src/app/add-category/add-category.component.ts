import { Component, OnInit } from '@angular/core';
import { Category } from '../models/category.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DataService } from '../shared/data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {

  categoryForm : FormGroup;
  category : Category = new Category();

  constructor(private _snackBar: MatSnackBar,private dataservice:DataService, private form: FormBuilder, private router: Router) { }

  ngOnInit(): void {
    this.categoryForm = this.form.group({
      CategoryName : ['', Validators.required],
  });
  }

  onSubmit() {
    if (this.categoryForm.valid) {
      this.updateCategoryValues();
      // tslint:disable-next-line:prefer-const
      this.dataservice.postCategory(this.category).subscribe (
        result =>  {console.log(result); },
        error =>  {console.log(error)}
  );
  this._snackBar.open("Category Added", "Close", {
    duration: 1000,});
    this.categoryForm.reset();
    } 
    
    else {
      alert("invalid"); 
    }
  }


  updateCategoryValues() {
    this.category.CategoryName = this.categoryForm.get('CategoryName').value;
    this.category.IsDeleted = false;
  }
}
