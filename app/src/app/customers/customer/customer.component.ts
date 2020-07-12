import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomersService } from '../customers.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  customer: any; //todo interface
  feedback: any; //todo interface

  constructor(private route: ActivatedRoute, private customersService: CustomersService) { }

  ngOnInit(): void {

    this.feedback = {
      loading: true,
      text: 'Loading Customer Details',
      textClass: 'text-primary'
    }

    this.route.queryParams.subscribe((params: any) => {
      //will implement a routeGuard to ensure id is being passed
      if(params.id){
        this.customersService.getCustomer(params.id)
          .subscribe((res: any) => {
            //implement interface
            this.customer = res.data;
            delete this.feedback;
          })
      }
    })
  }

}
