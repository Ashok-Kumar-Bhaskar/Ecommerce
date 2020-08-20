import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AddProductComponent } from './add-product.component';


const routes: Routes = [
  {
    path : 'addproduct',
    component : AddProductComponent,
  }
];



@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AddProductRoutingModule { }
