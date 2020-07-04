import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Address, MyFormControl } from 'src/app/shared/interfaces/address';
import { AddressesModule } from './addresses.module';
 
@Component({
  selector: 'app-addresses',
  templateUrl: './addresses.component.html',
  styleUrls: ['./addresses.component.css']
})
export class AddressesComponent implements OnInit {

  addressForm: FormGroup;
  @Input() parentForm: FormGroup;
  @Input() preFilledData: Address; //todo interface  
  @Output() updateParent: EventEmitter<any> = new EventEmitter();

  myAddressModel: Address;

  constructor() { }

  ngOnInit(): void {

    this.addressForm = new FormGroup({
      addressLine1: new FormControl((this.preFilledData && this.preFilledData.addressLine1 ? this.preFilledData.addressLine1 : undefined), Validators.maxLength(50)), 
      addressLine2: new FormControl((this.preFilledData && this.preFilledData.addressLine2 ? this.preFilledData.addressLine2 : undefined))
    })

    //this.addressForm.controls.addressLine1.setValidators()

    /* functionality to add parent controls to the child... maybe useful?
    Object.keys(this.parentForm.controls).forEach((key, x) => {
      console.log(this.parentForm.controls[key]);      
      this.addressForm.addControl(key, this.parentForm.controls[key]);
    })*/

  }

  updated = () => {
    this.updateParent.emit(this.addressForm.value);
  }

}
