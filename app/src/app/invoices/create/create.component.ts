import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  invoiceForm: FormGroup;

  constructor() { }

  ngOnInit(): void {

    this.invoiceForm = new FormGroup({
      customerName: new FormControl(undefined, Validators.required),
      customerEmail: new FormControl(undefined, [Validators.required, Validators.email])      
    })

  }

}
