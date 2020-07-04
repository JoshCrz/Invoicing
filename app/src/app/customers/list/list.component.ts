import { Component, OnInit } from '@angular/core';
import { CustomersService } from '../customers.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  customers: any;

  constructor(private customersService: CustomersService) { }

  ngOnInit(): void {

this.customersService.getCustomers()
    .subscribe((res: any) => {
      this.customers = res;
    })
  }

}
