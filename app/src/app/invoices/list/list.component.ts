import { Component, OnInit } from '@angular/core';
import { InvoicesService } from '../invoices.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  
  invoices: any = [];

  constructor(
    private invoicesService: InvoicesService,
    private router: Router
  ) { }

  ngOnInit(): void {

        this.invoices = this.invoicesService.getAll()

  }

  navigateToInvoice = (id) => {
    this.router.navigate(['/invoice', id]);
  }

}

