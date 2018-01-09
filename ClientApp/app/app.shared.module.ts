import { AuthModule } from './auth.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { ToastyModule} from 'ng2-toasty';


import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { CustomerComponent } from './components/customer/customer.component';
import { LoginComponent } from './components/login/login-component';
import { CustomerFormComponent } from './components/customer-form/customer-form.component';
import { CustomerService } from './services/customer.service';
import { AuthService } from './services/auth.service';
import { AUTH_PROVIDERS, JwtHelper } from "angular2-jwt";
import { provideAuth } from 'angular2-jwt';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        CustomerComponent,
        CustomerFormComponent,
        LoginComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        AuthModule,
        ToastyModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'customer', component: CustomerComponent },
            { path: 'customer/new', component: CustomerFormComponent },
            { path: 'login', component: LoginComponent },
            { path: 'update-customer/:id', component: CustomerFormComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        // { provide : ErrorHandler, useClass : AppErrorHandler},
        CustomerService,
        AuthService,
        AUTH_PROVIDERS,
        JwtHelper
    ]
})
export class AppModuleShared {
}
