import { Component, OnInit } from '@angular/core';
import { CustomersService } from './customers.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  constructor(private customersService: CustomersService) { }

  ngOnInit(): void {

   /* this.customersService.getCustomers().subscribe((res: any) => {
      console.log(res);
    })*/
    
  }

}
