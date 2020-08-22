import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { PrintpdfComponent } from './printpdf.component';

const routes: Routes = [
  {
    path : 'printpdf',
    component : PrintpdfComponent,
  }
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PrintpdfRoutingModule { }
