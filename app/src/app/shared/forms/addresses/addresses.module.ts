import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddressesComponent } from './addresses.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [AddressesComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [AddressesComponent]
})
export class AddressesModule { }
