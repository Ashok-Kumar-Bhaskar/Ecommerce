import { Component, OnInit } from '@angular/core';
import { Address } from '../models/address.model';
import { DataService, lightTheme } from '../shared/data.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-add-address',
  templateUrl: './add-address.component.html',
  styleUrls: ['./add-address.component.css']
})
export class AddAddressComponent implements OnInit {

  addressForm : FormGroup;
  address : Address = new Address();
  userid : number;
   constructor(private _snackBar: MatSnackBar,public jwtHelper: JwtHelperService, private dataservice: DataService, private form: FormBuilder,private router: Router) { }

  private setTheme(theme: {}) {
    Object.keys(theme).forEach(k =>
      document.documentElement.style.setProperty(`--${k}`, theme[k])
    );
  }

  ngOnInit(): void {
    this.setTheme(lightTheme);
    const token=localStorage.getItem('token');
    const admin=localStorage.getItem('isAdmin');
    const expire = this.jwtHelper.isTokenExpired(token);
    if(token==null || expire || admin==='1')
    {
      this.router.navigate(['/signin']);
    }
    this.userid = JSON.parse(localStorage.getItem("userid"));
    this.addressForm = this.form.group({
      Door: [null, Validators.required],
      Street1: ['', Validators.required],
      Street2: [''],
      Area: ['', Validators.required],
      City: ['', Validators.required],
      State: ['', Validators.required],
      Pincode: [null, [Validators.required, Validators.pattern('[1-9]\\d{5}')]],
      Contact: [null, [Validators.required, Validators.pattern('[6-9]\\d{9}')]],
      AlternateContact: [null,Validators.pattern('[6-9]\\d{9}')],

    });
  }

  onSubmit(){
    if (this.addressForm.valid) {
      this.updateAddressValues();
      // tslint:disable-next-line:prefer-const
      this.dataservice.postAddress(this.address).subscribe (
          result =>  {console.log(result); },
          error =>  console.log(error)
    );
    this._snackBar.open("New Address Added", "Close", {
      duration: 2000,verticalPosition: 'top',horizontalPosition: 'right',panelClass: ['red-snackbar'],});
    this.addressForm.reset();
    this.router.navigate(['/order']);
    } 
    else {
      this._snackBar.open("Please Enter Valid Address", "Close", {
        duration: 2000,verticalPosition: 'top',horizontalPosition: 'right',panelClass: ['red-snackbar'],});
      console.log("invalid");
    }
  }

  goBack()
  {
    this.router.navigate(['/order']);
    window.location.reload();
  }
  updateAddressValues()
  {
    this.address.User_ID = this.userid;
    this.address.Door = this.addressForm.get('Door').value;
    this.address.Street1 = this.addressForm.get('Street1').value;
    this.address.Street2 = this.addressForm.get('Street2').value;
    this.address.Area = this.addressForm.get('Area').value;
    this.address.City = this.addressForm.get('City').value;
    this.address.State = this.addressForm.get('State').value;
    this.address.Pincode = this.addressForm.get('Pincode').value;
    this.address.Contact = this.addressForm.get('Contact').value;
    this.address.AlternateContact = this.addressForm.get('AlternateContact').value;
    this.address.IsDeleted = false;
  }


}
