import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http'; 
import 'rxjs/add/operator/map';
import { CustomerModel } from './../models/customer';
import { AuthHttp } from "angular2-jwt";

@Injectable()
export class CustomerService {
  private readonly customerEndpoint = '/api/customerapi';
  public headers = new Headers();


  constructor(private http: Http, private authHttp: AuthHttp) {

    this.headers.append('Content-Type', 'application/json');
    this.headers.append('Authorization', 'Bearer ' + localStorage.getItem("JWTToken"));
     
  }

  getCustomers() {

    return this.http.get(this.customerEndpoint, { headers: this.headers})
      .map(res => res.json());
  }

  getCustomerById(id: any) {
    return this.http.get(this.customerEndpoint + '/' + id, { headers: this.headers})
      .map(res => res.json());
  }

   delete(id: any) {
    return this.http.delete(this.customerEndpoint + '/' + id, { headers: this.headers})
      .map(res => res.json());
  }

  update(customer: CustomerModel) {
    console.log(customer);  
    
    return this.http.put(this.customerEndpoint + '/' + customer.id, customer, { headers: this.headers})
      .map(res => res.json());
  }

  create(customer: CustomerModel) {
    return this.http.post(this.customerEndpoint, customer, { headers: this.headers})
      .map(res => res.json());
  }

}
