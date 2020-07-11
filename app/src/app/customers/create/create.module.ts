import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { AddressesModule } from '../../shared/forms/addresses/addresses.module';

import { CreateRoutingModule } from './create-routing.module';
import { CreateComponent } from './create.component';
import { FeedbackModule } from '../../shared/feedback/feedback.module';

@NgModule({
  declarations: [CreateComponent],
  imports: [
    CommonModule,
    CreateRoutingModule,
    ReactiveFormsModule,
    AddressesModule,
    FeedbackModule
  ]
})
export class CreateModule { }
