import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {

    private GivenName : any = '';
    ngOnInit() {
        this.GivenName = localStorage.getItem("Name");
        //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
        //Add 'implements OnInit' to the class.     
    }
}
