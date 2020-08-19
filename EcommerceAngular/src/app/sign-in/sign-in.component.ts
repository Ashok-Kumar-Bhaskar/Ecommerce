import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../models/user.model';
import { DataService, lightTheme } from '../shared/data.service';
import { Signin } from '../models/signin.model';
import jwt_decode from 'jwt-decode';
import { JwtHelperService } from '@auth0/angular-jwt';


@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  signinForm : FormGroup;
  expire: Boolean;
  signin : Signin = new Signin(); 
  postError = false;
  postErrorMessage = '';
  emailRegx = /^(([^<>+()\[\]\\.,;:\s@"-#$%&=]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,3}))$/;
  user : User;
  constructor(private router: Router, private dataservice: DataService, private form: FormBuilder, public jwtHelper: JwtHelperService) { }

  private setTheme(theme: {}) {
    Object.keys(theme).forEach(k =>
      document.documentElement.style.setProperty(`--${k}`, theme[k])
    );
  }

  ngOnInit(): void {
    this.setTheme(lightTheme);
    const token=localStorage.getItem('token');
    this.expire = this.jwtHelper.isTokenExpired(token);
    if(token!=null && !this.expire ){
      this.router.navigate(['/home']);
    }

    this.signinForm = this.form.group({
      Username: ['', Validators.required],
      Password: ['', Validators.required]
    });
  }

  onHttpError(error: any) {
    console.log('error:', error);
    this.postError = true;
    this.postErrorMessage = error.error.Message;
    console.log(this.postErrorMessage);
  }

  onSubmit() {
    this.updateSigninValues();
    
    if (this.signinForm.valid) {
      console.log(' in onSubmit:', this.signinForm.valid);
      
      this.dataservice.postSigninForm(this.signin).subscribe (
        result => {
          localStorage.setItem('token', result);
          this.setValues(result);
          this.router.navigate(['/home']);
        },
        error=>this.onHttpError(error));
    } 
    else {
      this.postError = true;
      this.postErrorMessage = 'Please Fix the above errors';      
    }
  }

  setValues(result){
    console.log("logged");
    var decoded = jwt_decode(result);
    console.log(decoded);
    localStorage.setItem('isUsername',decoded['unique_name']);
    localStorage.setItem('userid',decoded['certserialnumber']);
    if(decoded['role'] == "Admin"){
      localStorage.setItem('isAdmin','1');       
    }
    else{
      localStorage.setItem('isAdmin','0');
    }

    this.dataservice.getUserDetails(decoded['certserialnumber']).subscribe (
      result => { this.user = result;
        localStorage.removeItem("user");
        localStorage.setItem("user",JSON.stringify(this.user));
      },
      error=>console.log(error));
  }
  updateSigninValues()
  {
    this.signin.Username = this.signinForm.get("Username").value;
    this.signin.Password = this.signinForm.get("Password").value;
  }

  signup()
  {
    this.router.navigate(['/signup']);
  }
}
