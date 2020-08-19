import { Component, OnInit } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { FormControl, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { DataService } from '../../shared/data.service'

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  color: ThemePalette = 'accent';
  checked = false;
  disabled = false;
  darkTheme =  new FormControl(false);
  show : boolean = true;
  userRole : string;

  constructor(private router : Router,private dataservice : DataService,public dialog: MatDialog,
    private form: FormBuilder) { 
      this.darkTheme.valueChanges.subscribe(value => {
      if (value) {
        console.log(this.darkTheme.value);
        this.dataservice.toggleDark();
      } else {
        this.dataservice.toggleLight();
      }
    });

    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };}

  ngOnInit(): void {
    this.userRole = JSON.parse(localStorage.getItem("isAdmin"));
  }

  changetheme()
  {
    this.show = !this.show;
   
  }

  goToHome()
  {
    localStorage.removeItem("product");
    this.router.navigate(["/home"]);

  }

  logout()
  {
    localStorage.clear();
    this.router.navigate(['/signin']);
  }

}
