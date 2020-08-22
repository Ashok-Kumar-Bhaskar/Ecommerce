import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DataService } from '../shared/data.service';
import { map } from 'rxjs/operators';
import { Cart } from '../models/cart.model';
import {FormsModule} from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  displayedColumns: string[] = ['item','quantity','cost','delete','total'];
 
  user : string;
  
  dataSource : Cart[] = [];

  GrandTotal : any;
  getTotalCost() {
    this.GrandTotal = this.dataSource.map(t => t.Total ).reduce((acc, value) => acc + value, 0);
    localStorage.setItem("cartTotalValue", this.GrandTotal);
    return this.dataSource.map(t => t.Total ).reduce((acc, value) => acc + value, 0);
  }



  constructor(private _snackBar: MatSnackBar,public jwtHelper: JwtHelperService, private dataservice : DataService, private router:Router) { }

  ngOnInit(): void {
    const token=localStorage.getItem('token');
    const admin=localStorage.getItem('isAdmin');
    const expire = this.jwtHelper.isTokenExpired(token);
    if(token==null  || expire|| admin==='1')
    {
      this.router.navigate(['/signin']);
    }

    this.user = localStorage.getItem("isUsername") ;
    
    this.dataservice.getCartItems(this.user).subscribe(  
      data => {  this.dataSource = data ;
      console.log(this.dataSource);}
      ,err=>{ console.log(err); });  
  }

  goToOrders()
  {
    if(this.GrandTotal == 0)
    {
      this._snackBar.open("Please add Items to Cart", "Close", {
        duration: 2000,verticalPosition: 'top',horizontalPosition: 'right',panelClass: ['red-snackbar'],});
    }
    else{
      this.router.navigate(['/order']);
    }
   
  }

  Delete(element)
  {
    this.dataservice.DeleteItems(element.Items_ID).subscribe(  
      result => { console.log(result);},
      err=>{ console.log(err);});

      this._snackBar.open("Item Deleted From Cart", "Close", {
        duration: 2000,verticalPosition: 'top',horizontalPosition: 'right',panelClass: ['red-snackbar'],});
    
    this.dataservice.putInventoryItems(element.Commodity_ID,element.Quantity).subscribe(  
      result => { console.log(result);},
      err=>{ console.log(err);});
      
    window.location.reload();
  }
}
