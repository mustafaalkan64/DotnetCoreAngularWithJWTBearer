import { Component, OnInit } from '@angular/core';
import { AuthService } from './../../services/auth.service';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {
    
    public authanticated: boolean;
    constructor(private auth: AuthService)
    { }

    ngOnInit() {
        //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
        //Add 'implements OnInit' to the class.
    }

    ifAuthanticated() {
        return this.auth.authenticated();
    }

    _logout() {
        this.auth.logout();
    }
}
