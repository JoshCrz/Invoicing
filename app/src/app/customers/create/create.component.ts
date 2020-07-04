import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { formatCurrency } from '@angular/common';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  customerForm: FormGroup;

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

    //create nested form to handle addresses and contacts

  }

}
