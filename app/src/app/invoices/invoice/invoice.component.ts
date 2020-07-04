import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InvoicesService } from '../invoices.service';
 

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css']
})
export class InvoiceComponent implements OnInit {

  id: any;
  invoice: any; //todo interface

  constructor(
    private route: ActivatedRoute,
    private invoicesService: InvoicesService
    ) { }

  ngOnInit(): void {
  
    this.route.params.subscribe((params: any) => {
      if(params.guid) {
        //this.id = params.guid;
        this.invoicesService.getById(params.guid);
      }
    })

  }

}
