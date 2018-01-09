import { loginModel } from './../models/loginModel';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { tokenNotExpired } from 'angular2-jwt';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';

@Injectable()
export class AuthService {

    private readonly authEndpoint = '/api/auth';

    constructor(private http: Http,
    private router: Router) { }

    login(credentials: any) {
        return  this.http.post(this.authEndpoint, credentials)
            .map(res => res.json());
    }

    authenticated() : boolean {

        if (typeof window !== 'undefined') {
            return tokenNotExpired('JWTToken');
        }
        else 
            return false;
    }

    logout() {
        localStorage.removeItem('JWTToken');
        localStorage.removeItem('Email');
        localStorage.removeItem('Name');
        this.router.navigate(['/login/']);
    }
}





