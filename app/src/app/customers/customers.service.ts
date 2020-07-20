import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { FormGroup, FormControl, Validators} from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  constructor(private _http: HttpClient) { }

  getCustomers = () => {    

    let headers = new HttpHeaders();
    headers = headers.set('Access-Control-Allow-Origin', '*');    
    headers = headers.set('withCredentials', 'true');
    return this._http.get(
      `${environment.apiUrl}Customers`, {headers}
    )
    
  }

  createCustomer = (customerModel) => {
   return this._http.post(
     `${environment.apiUrl}Customers`, 
      customerModel
   ) 
  }

  getCustomer = (id) => {
    return this._http.get(
      `${environment.apiUrl}Customers/` + id
    )
  }

  deleteCustomer = (id) => {
    return this._http.delete(
      `${environment.apiUrl}customers/` + id
    )
  }

  generateCustomerForm = (customer?) => {
    let formGroup = new FormGroup({
      companyName: new FormControl(customer && customer.companyName ? customer.companyName : '', Validators.required),
      natureOfBusiness: new FormControl(customer && customer.natureOfBusiness ? customer.natureOfBusiness : '', Validators.required),
      customerStatusID: new FormControl(customer && customer.customerStatusID ? customer.customerStatusID : null, Validators.required),
      customerTypeID: new FormControl(customer && customer.customerTypeID ? customer.customerTypeID : null, Validators.required),
      websiteUrl: new FormControl(customer && customer.websiteUrl ? customer.websiteUrl : ''),
      registrationNumber: new FormControl(customer && customer.registrationNumber ? customer.registrationNumber : ''),
      vatNumber: new FormControl(customer && customer.vatNumber ? customer.vatNumber : '')
    })
    return formGroup;
  }

}
