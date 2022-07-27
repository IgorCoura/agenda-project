import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InteractionViewComponent } from './interaction-view/interaction-view.component';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';



@NgModule({
  declarations: [
    InteractionViewComponent,
  ],
  imports: [
    MatListModule,
    CommonModule,
    MatCardModule
  ],
  exports: [
    InteractionViewComponent,
  ]
})
export class InteractionModule { }
