import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { InventoryComponent } from './inventory.component';

const routes: Routes = [
  {
    path : 'inventory',
    component : InventoryComponent,
  }
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InventoryRoutingModule { }
