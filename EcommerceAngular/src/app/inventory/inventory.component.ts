import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../shared/data.service';
import { Inventory } from '../models/inventory.model';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.css']
})
export class InventoryComponent implements OnInit {

  displayedColumns: string[] = ['ID','item','seller','cost','quantity','stock','qty','order'];
  dataSource : Inventory[] = [];
  qty : number;
  
  qtychange(newValue) {
    this.qty = newValue;
    console.log(this.qty);
  } 

  constructor(private dataservice : DataService, private router:Router) { }

  ngOnInit(): void {
    this.dataservice.getInventoryItems().subscribe(  
      data => {  this.dataSource = data ;
      console.log(this.dataSource);
    },err=>{ console.log(err);});
  }

  Order(id)
  {
    this.dataservice.putInventoryItems(id,this.qty).subscribe(  
      result => {  console.log(result);
    },err=>{ console.log(err);});
  }
}