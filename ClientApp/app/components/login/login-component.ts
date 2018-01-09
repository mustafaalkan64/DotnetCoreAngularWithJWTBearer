import { NavMenuComponent } from './../navmenu/navmenu.component';
import { loginModel } from './../../models/loginModel';
import { Component, OnInit } from '@angular/core';
import { AuthService } from './../../services/auth.service';
import { NgForm } from '@angular/forms';
import { ToastyService } from "ng2-toasty";
import { ActivatedRoute, Router } from '@angular/router';
import { JwtHelper } from 'angular2-jwt'

interface Credentials {
  UserName: string,
  Password: string
}

//*ngIf="!auth.loggedIn()"
@Component({
  selector: 'login',
  template: `
    <h3> Login </h3>
    <form #f="ngForm"  (ngSubmit)="onLogin(f)">

        <label>Username </label>
        <input type="text" class="form-control"  [(ngModel)]="credentials.UserName" name="UserName" required #UserName="ngModel" />

        <label>Password </label>
        <input type="password" class="form-control"  [(ngModel)]="credentials.Password" name="Password" #Password="ngModel" required />

    <br/>
    <input type="submit" value="Login" class="btn btn-primary"/>
    </form>
  `
})

export class LoginComponent {

  credentials: Credentials = {
    UserName: '',
    Password: ''
  };

  constructor(private auth: AuthService,
    private toastyService: ToastyService,
    private jwt : JwtHelper,
    private router: Router)
  { }

  ngOnInit() {
    if (this.auth.authenticated()) {
      this.router.navigate(['/home/']);
    }
  }

  onLogin(credentials: NgForm) {

    this.auth.login(credentials.value)
      .subscribe(
      data => {
        // Handle result
        localStorage.setItem('JWTToken', data.token);
        debugger;
        var decoded_data = this.jwt.decodeToken(data.token);
        localStorage.setItem("Email", decoded_data.email);
        localStorage.setItem("Name", decoded_data.given_name);
        this.router.navigate(['/home/']);
      },
      error => {
        
            console.log(error);
            this.toastyService.error({
              title: 'HATA!',
              msg: error._body,
              theme: 'bootstrap',
              showClose: true,
              timeout: 5000
            });
          }
      );
  }
}