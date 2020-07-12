import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CustomersService } from '../customers.service';
import { Router } from '@angular/router';

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

  data: any = {
    addressLine1: "39",
    addressLine2: "Ironbridge Road"
  }

  constructor(
    private customersService: CustomersService,
    private router: Router
    ) { }

  ngOnInit(): void {

    this.customerForm = new FormGroup({      
      companyName: new FormControl('', Validators.required),
      natureOfBusiness: new FormControl('', Validators.required),
      customerStatusID: new FormControl(null, Validators.required),
      customerTypeID: new FormControl(null, Validators.required),
      websiteUrl: new FormControl(),
      registrationNumber: new FormControl(),
      vatNumber: new FormControl()
    })

  }

  submit = (form) => {

    this.submitted = true;
    console.log(form.value)

    this.feedback = {
      loading: true,
      textClass: 'text-primary',
      text: 'Loading'
    }    

/*
    if(form.valid){

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
    }*/
  }


  /*
  childFormEvent = (value) => {
    console.log(value);    
  }
  */

}
