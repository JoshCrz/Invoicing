import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CustomersService } from '../customers.service';
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
    private route: ActivatedRoute
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
              this.customerForm = this.customersService.generateCustomerForm(customer.data);              
              delete this.feedback;
            } else {
              //feedback error 
            }
          })        
      } else {
        this.customerForm = this.customersService.generateCustomerForm();
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
