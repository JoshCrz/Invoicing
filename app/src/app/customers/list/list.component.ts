import { Component, OnInit } from '@angular/core';
import { CustomersService } from '../customers.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  customers: any; //todo interface   
  feedback: any; //todo interface

  constructor(private customersService: CustomersService) { }

  ngOnInit(): void {

    this.feedback = {
      loading: true,
      textClass: 'text-primary',
      text: 'Loading Customers'
    }

    this.customersService.getCustomers()
      .subscribe((res: any) => {
        this.customers = res.data;
        delete this.feedback;
      }, error => {
        this.feedback = {  
          loading: false,       
          textClass: 'text-danger',
          text: 'Error',
          icon: 'fas fa-exclamation-triangle',
          desc: (error.error && error.error.message) ? error.error.message : ''
        }
      })
  }

}
