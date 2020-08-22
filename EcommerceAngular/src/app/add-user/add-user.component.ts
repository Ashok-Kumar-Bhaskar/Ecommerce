import { Component, OnInit } from '@angular/core';
import { DataService, lightTheme } from '../shared/data.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../models/user.model';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  signupForm : FormGroup;
  user: User = new User()
  emailRegx = /^(([^<>+()\[\]\\.,;:\s@"-#$%&=]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,3}))$/;

  constructor(private dataservice: DataService,public jwtHelper: JwtHelperService,  private form: FormBuilder,private router: Router) { }

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
    if(token==null || expire || admin==='0')
    {
      this.router.navigate(['/signin']);
    }

    this.signupForm = this.form.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Email: ['',[Validators.required, Validators.pattern(this.emailRegx)]],
      DefaultContact: [null, [Validators.required, Validators.pattern('[6-9]\\d{9}')]],
      Password: ['', Validators.required],
      Username: ['', Validators.required],
    });
  }

  onSubmit(){
    if (this.signupForm.valid) {
      this.updateUserValues();
      // tslint:disable-next-line:prefer-const
      this.dataservice.postSignupForm(this.user).subscribe (
          result =>  {console.log(result); },
          error =>  console.log(error)
    );
    this.signupForm.reset();
    } 
    else {
      console.log("invalid");
    }
  }

  updateUserValues()
  {
    this.user.FirstName = this.signupForm.get('FirstName').value;
    this.user.LastName = this.signupForm.get('LastName').value;
    this.user.Email = this.signupForm.get('Email').value;
    this.user.Username = this.signupForm.get('Username').value;
    this.user.Password = this.signupForm.get('Password').value;
    this.user.DefaultContact = this.signupForm.get('DefaultContact').value;
    this.user.Role = "Admin";
  }


}
