import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { InvoicesService } from '../invoices.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
  providers: [InvoicesService]
})
export class CreateComponent implements OnInit {

  invoiceForm: FormGroup;
  submitted: boolean;

  constructor(private invoiceService: InvoicesService) { }

  ngOnInit(): void {

    this.invoiceForm = new FormGroup({
      customerName: new FormControl(undefined, Validators.required),
      customerEmail: new FormControl(undefined), //[Validators.required, Validators.email]
      customerCompany: new FormControl(undefined)    
    })

  }

  submit(form){

    this.submitted = true;

    if(form.valid){
      
      this.invoiceService.create(form.value);

    } else {
      window.scrollTo(0, 0);
    }

  }

}
