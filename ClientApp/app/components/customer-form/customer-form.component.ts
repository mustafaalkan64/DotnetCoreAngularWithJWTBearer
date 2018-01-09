import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { CustomerService } from './../../services/customer.service';
import { CustomerModel } from './../../models/customer';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastyService } from "ng2-toasty";

@Component({
    selector: 'customer-form',
    templateUrl: './customer-form.component.html'
})
export class CustomerFormComponent implements OnInit {

    private customer: CustomerModel = {
        id: 0,
        name: '',
        surname: '',
        email: '',
        address: '',
        phoneNumber: '',
        age: 0,
        salary: 0,
        customerFavorites: []
    };
    private customerID: any;

    constructor(private customerService: CustomerService,
        private route: ActivatedRoute,
        private toastyService: ToastyService,
        private router: Router) {

        route.params.subscribe(p => {
            this.customer.id = +p['id'] || 0;
        });
    }

    ngOnInit() {

        if (this.customer.id) {
            this.customerService.getCustomerById(this.customer.id)
                .subscribe(
                result => {
                    // Handle result
                    this.customer = result;
                    console.log(this.customer);
                },
                error => {
                    console.log(error);
                    this.toastyService.error({
                        title: 'HATA!',
                        msg: error,
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                }
                );
        }
    }

    submit() {
        var result$ = (this.customer.id) ? this.customerService.update(this.customer) :
            this.customerService.create(this.customer);
        result$.subscribe(result => {
            this.toastyService.success({
                title: 'İşleminiz Başarılı',
                msg: 'Müşteri Başarıyla Kaydedildi.',
                theme: 'bootstrap',
                showClose: true,
                timeout: 5000
            });
            this.router.navigate(['/customer/']);
        },
            error => {
                this.toastyService.error({
                    title: 'HATA!',
                    msg: 'Giriş Değerleri Doğru Şekilde Değildi.',
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });
            }
        );
    }
}