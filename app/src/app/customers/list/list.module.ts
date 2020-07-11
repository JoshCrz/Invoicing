import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FeedbackModule } from '../../shared/feedback/feedback.module';
import { ListRoutingModule } from './list-routing.module';

import { ListComponent } from './list.component';

@NgModule({
  declarations: [ListComponent],
  imports: [
    CommonModule,
    ListRoutingModule,
    FeedbackModule
  ]
})
export class ListModule { }
