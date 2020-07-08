import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { CustomersService } from '../customers.service';


@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  customerForm: FormGroup;
  addressForm: FormGroup;
  submitted: boolean;

  data: any = {
    addressLine1: "39",
    addressLine2: "Ironbridge Road"
  }

  constructor(private customersService: CustomersService) { }

  ngOnInit(): void {

    this.customerForm = new FormGroup({      
      companyName: new FormControl(),
      natureOfBusiness: new FormControl(),
      customerStatusID: new FormControl(),
      customerTypeID: new FormControl(),
      websiteUrl: new FormControl(),
      registrationNumber: new FormControl(),
      vatNumber: new FormControl()      
    })

  }

  submit = (form) => {

    this.submitted = true;
    console.log(form.value)

    if(form.valid){

      this.customersService.createCustomer(form.value)
        .subscribe((res: any) => {
          console.log(res);
        })      
    }
  }


  /*
  childFormEvent = (value) => {
    console.log(value);    
  }
  */

}
