import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CustomersService } from '../customers.service';
import { AddressService } from '../../shared/services/address.service';
import { Router, ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  customerForm: FormGroup;
  addressForm: FormGroup;
  submitted: boolean;
  feedback: any; //todo interface  
  customer: any; //todo interface

  data: any = {
    addressLine1: "39",
    addressLine2: "Ironbridge Road"
  }

  constructor(
    private customersService: CustomersService,
    private router: Router,
    private route: ActivatedRoute,
    private addressService: AddressService
    ) { }

  ngOnInit(): void {

    this.feedback = {
      loading: true,
      textClass: 'text-primary',
      text: 'Loading'
    }    

    this.route.queryParams.subscribe((res: any) => {      
      console.log(res)
      if(res.id){
        this.customersService.getCustomer(res.id)
          .subscribe((customer: any) => {
            if(customer && customer.data){

              //generate a customer form
              this.customerForm = this.customersService.generateCustomerForm(customer.data);

              this.customer = customer.data;
              delete this.feedback;
            } else {
              //feedback error 
            }
          })        
      } else {

        //new customer account, create an empty form
        this.customerForm = this.customersService.generateCustomerForm();

        //generate an address form
        this.addressForm = this.addressService.generateAddressForm();
        delete this.feedback;
      }
    })
  }

  submit = (form) => {

    this.submitted = true;
    
    if(form.valid){

      this.feedback = {
        loading: true,
        textClass: 'text-primary',
        text: 'Loading'
      }    

      this.customersService.createCustomer(form.value)
        .subscribe((res: any) => {
          //defensive coding
          console.log(res)
          if(res.error){

          } 
          else if(res && res.data){
            //route to new customer
            this.router.navigate(['customers/customer'], { queryParams: {id: res.data.customerID}})
          }
        })      
    }
  }
}
