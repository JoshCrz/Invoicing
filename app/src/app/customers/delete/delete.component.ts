import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { CustomersService } from '../customers.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {

  feedback: any; //todo interface
  customer: any; //todo interface
  customerDeleted: boolean;

  constructor(private route: ActivatedRoute, private customersService: CustomersService) { }

  ngOnInit(): void {
    
    this.route.queryParams.subscribe((params: any) => {
      //todo - route guard
      if(params.id){
        this.customersService.getCustomer(params.id)  
          .subscribe((res: any) => {
            this.customer = res.data;
          })

      }
    })

  }

  delete(customer){

    this.feedback = {
      loading: true,
      text: 'Deleting Customer',
      textClass: 'text-danger'
    }


    this.customersService.deleteCustomer(customer.customerID) 
      .subscribe((res: any) => {
        this.customerDeleted = true;
        this.feedback = {
          loading: false,
          text: 'Customer Deleted',
          textClass: 'text-danger',
          icon: 'fas fa-exclamation-triangle'
        }
      })
  }

}
