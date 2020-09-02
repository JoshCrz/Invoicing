import { Injectable } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
@Injectable({
  providedIn: 'root'
})
export class AddressService {

  constructor() { }

  generateAddressForm = (existingAddress?) => {
    const formGroup = new FormGroup({
      adddressLine1: new FormControl(existingAddress && existingAddress.companyName ? existingAddress.companyName : '', Validators.required),
      addressLine2: new FormControl(existingAddress && existingAddress.natureOfBusiness ? existingAddress.natureOfBusiness : '', Validators.required),
      addressLine3: new FormControl(existingAddress && existingAddress.customerStatusID ? existingAddress.customerStatusID : null, Validators.required),
      postCode: new FormControl(existingAddress && existingAddress.customerTypeID ? existingAddress.customerTypeID : null, Validators.required),
      town: new FormControl(existingAddress && existingAddress.websiteUrl ? existingAddress.websiteUrl : ''),
      county: new FormControl(existingAddress && existingAddress.registrationNumber ? existingAddress.registrationNumber : ''),
      country: new FormControl(existingAddress && existingAddress.vatNumber ? existingAddress.vatNumber : '')
    })
    return formGroup;
  }

}
