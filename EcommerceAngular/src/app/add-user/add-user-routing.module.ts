import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddUserComponent } from './add-user.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path : 'adduser',
    component : AddUserComponent,
  }
];

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class AddUserRoutingModule { }
