import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

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

}
