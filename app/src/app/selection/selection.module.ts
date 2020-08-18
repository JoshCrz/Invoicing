import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSliderModule } from '@angular/material/slider';

import { SelectionRoutingModule } from './selection-routing.module';
import { SelectionComponent } from './selection.component';


@NgModule({
  declarations: [SelectionComponent],
  imports: [
    CommonModule,
    SelectionRoutingModule,
    MatSliderModule
  ]
})
export class SelectionModule { }
