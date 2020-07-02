import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  constructor(private _http: HttpClient) { }

  getCustomers = () => {
    console.log('get customers')
    return this._http.get(
      `${environment.apiUrl}customer/`
    )
    
  }

}
