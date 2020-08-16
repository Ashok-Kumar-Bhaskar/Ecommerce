import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { OrderComponent } from './order.component';

const routes: Routes = [
  {
    path : 'order',
    component : OrderComponent,
  }
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrderRoutingModule { }
