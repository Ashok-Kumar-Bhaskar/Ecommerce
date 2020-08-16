import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SignupComponent } from './signup.component';


const routes: Routes = [
  {
    path : 'signup',
    component : SignupComponent,
  }
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SignupRoutingModule { }