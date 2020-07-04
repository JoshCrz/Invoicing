import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';



@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  customerForm: FormGroup;
  addressForm: FormGroup;

  data: any = {
    addressLine1: "39",
    addressLine2: "Ironbridge Road"
  }

  constructor() { }

  ngOnInit(): void {

    this.customerForm = new FormGroup({
      id: new FormControl(),
      companyName: new FormControl(),
      natureOfBusiness: new FormControl(),
      companyStatusId: new FormControl(),
      companyTypeId: new FormControl(),
      websiteUrl: new FormControl(),
      registrationNumber: new FormControl(),
      vatNumber: new FormControl()      
    })


  }


  childFormEvent = (value) => {
    console.log(value);    
  }

}
