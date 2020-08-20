import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AddCategoryComponent } from './add-category.component';

const routes: Routes = [
  {
    path : 'addcategory',
    component : AddCategoryComponent,
  }
];



@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AddCategoryRoutingModule { }
