import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User } from '../models/user.model';
import { Router } from '@angular/router';
import { DataService } from '../shared/data.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  signupForm : FormGroup;
  user: User = new User()
  emailRegx = /^(([^<>+()\[\]\\.,;:\s@"-#$%&=]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,3}))$/;

  constructor(private dataservice: DataService, private form: FormBuilder,private router: Router) { }

  ngOnInit(): void {
    // const token=localStorage.getItem('token');
    // if(token==null)
    // {
    //   this.router.navigate(['/signin']);
    // }

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
    this.signupForm.reset(this.signupForm.value);
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
    this.user.Role = "User";
  }

}
