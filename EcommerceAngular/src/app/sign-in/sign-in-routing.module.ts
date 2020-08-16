import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SignInComponent } from './sign-in.component';


const routes: Routes = [
  {
    path : 'signin',
    component : SignInComponent,
  }
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SigninRoutingModule { }
