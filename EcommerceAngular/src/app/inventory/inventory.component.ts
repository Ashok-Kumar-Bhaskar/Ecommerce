import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../shared/data.service';
import { Inventory } from '../models/inventory.model';
import {MatTableDataSource} from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.css']
})
export class InventoryComponent implements OnInit {

  displayedColumns: string[] = ['ID','item','seller','cost','quantity','stock','qty','order'];
  dataSource = new MatTableDataSource();
  qty : number;

  
  qtychange(newValue) {
    this.qty = newValue;
    console.log(this.qty);
  } 

  constructor(private _snackBar: MatSnackBar,public jwtHelper: JwtHelperService, private dataservice : DataService, private router:Router) { }

  ngOnInit(): void {
    const token=localStorage.getItem('token');
    const admin=localStorage.getItem('isAdmin');
    const expire = this.jwtHelper.isTokenExpired(token);
    if(token==null  || expire || admin==='1')
    {
      this.router.navigate(['/signin']);
    }

    this.dataservice.getInventoryItems().subscribe(  
      data => {  this.dataSource=new  MatTableDataSource(data) as any ;
      console.log(this.dataSource);
      
    },err=>{ console.log(err);});

  }

  Order(id)
  {
    this.dataservice.putInventoryItems(id,this.qty).subscribe(  
      result => {  console.log(result);
      this._snackBar.open("Inventory Stock Updated", "Close", {
      duration: 1000,verticalPosition: 'top',horizontalPosition: 'right',panelClass: ['red-snackbar'],});
    },err=>{ console.log(err);});

    window.location.reload();
  }
}
