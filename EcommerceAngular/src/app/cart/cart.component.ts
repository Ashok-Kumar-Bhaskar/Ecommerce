import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DataService } from '../shared/data.service';
import { map } from 'rxjs/operators';
import { Cart } from '../models/cart.model';
import {FormsModule} from '@angular/forms';
import { Router } from '@angular/router';

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



  constructor(private dataservice : DataService, private router:Router) { }

  ngOnInit(): void {
    this.user = localStorage.getItem("isUsername") ;
    
    this.dataservice.getCartItems(this.user).subscribe(  
      data => {  this.dataSource = data ;
      console.log(this.dataSource);
    }
      ,err=>{  
        console.log(err);  
      }
    );
         
  }

  goToOrders()
  {
    this.router.navigate(['/order']);
  }

  Delete(id)
  {
    console.log(id);
  }
}
