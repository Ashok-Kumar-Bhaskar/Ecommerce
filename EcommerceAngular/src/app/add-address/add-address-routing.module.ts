import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AddAddressComponent } from './add-address.component';

const routes: Routes = [
  {
    path : 'addaddress',
    component : AddAddressComponent,
  }
];

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AddAddressRoutingModule { }
