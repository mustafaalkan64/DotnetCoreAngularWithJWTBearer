import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { CustomerService } from './../../services/customer.service';
import { CustomerModel } from './../../models/customer';
import { Router } from '@angular/router';
import { ToastyService } from "ng2-toasty";

@Component({
    selector: 'customer',
    templateUrl: './customer.component.html'
})
export class CustomerComponent {
    public customers: CustomerModel[];
    public customer: CustomerModel;

    constructor(private customerService: CustomerService,
        private toastyService: ToastyService,
        private router: Router) {

    }

    newCustomer(ID: number) {
        this.router.navigate(['/customer/new']);
    }

    getAllCustomers() {
        this.customerService.getCustomers()
            .subscribe(customers => this.customers = customers);
    }

    editCustomer(ID: number) {
        this.router.navigate(['/update-customer', ID]);
    }

    deleteCustomer(ID: number) {

        if(confirm("Silmek İstediğinize Emin misiniz? ")) {
            
            this.customerService.delete(ID)
            .subscribe(
                result => {
                    this.toastyService.success({
                        title: 'Başarılı',
                        msg: 'Silme İşlemi Başarılı.',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                    this.getAllCustomers();
                },
                error => {
                    console.log(error);
                }
            );
        }

    }

    ngOnInit() {
        this.getAllCustomers();
    }
}