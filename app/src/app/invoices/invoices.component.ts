import { Component, OnInit } from '@angular/core';
import { InvoicesService } from './invoices.service';

@Component({
  selector: 'app-invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.css']
})
export class InvoicesComponent implements OnInit {


  invoices: any;

  constructor(private invoicesService: InvoicesService) { }

  ngOnInit(): void {
    /*
    this.invoicesService.getAll()
      .subscribe((res: any) => {
        this.invoices = res;
      })
      */

  }

  
}
