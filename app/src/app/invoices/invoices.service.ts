import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class InvoicesService {

  constructor() { }


  create = (invoiceModel) => {

    let guid = (Math.random().toString(16)+"000000000").substr(2,8); 
    console.log(guid);
    invoiceModel['guid'] = guid;
    //localstorage until api
    localStorage.setItem('invoice #' + invoiceModel.guid, JSON.stringify(invoiceModel));

  }

  getAll = () => {    
    let invoices = [];
    Object.keys(localStorage).forEach(element => {      
      invoices.push(JSON.parse(localStorage[element]));
    });    
    return invoices;
  }

  getById = (id) => {

  }

  logMe = () => {
    console.log('LOGGED SErVICE')
  }

}
