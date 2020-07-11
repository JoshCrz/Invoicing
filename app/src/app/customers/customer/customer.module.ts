import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FeedbackModule } from '../../shared/feedback/feedback.module';

import { CustomerRoutingModule } from './customer-routing.module';
import { CustomerComponent } from './customer.component';


@NgModule({
  declarations: [CustomerComponent],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    FeedbackModule
  ]
})
export class CustomerModule { }
