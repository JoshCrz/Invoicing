import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class InvoicesService {

  constructor() { }

  create = (invoiceModel) => {

    let guid = (Math.random().toString(16)+"000000000").substr(2,8);     
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
    for(let i = 0; i < Object.keys(localStorage).length; i++){
      //if(id == Object.keys(localStorage)[i]);
      console.log(Object.keys(localStorage)[i]);
    }
  }

  logMe = () => {
    console.log('LOGGED SErVICE')
  }

}
