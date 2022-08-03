import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InteractionViewComponent } from './interaction-view/interaction-view.component';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { InteractionService } from 'src/app/services/interaction.service';
import { MatSnackBarModule } from '@angular/material/snack-bar';



@NgModule({
  declarations: [
    InteractionViewComponent,
  ],
  imports: [
    MatListModule,
    CommonModule,
    MatCardModule,
    MatSnackBarModule
  ],
  exports: [
    InteractionViewComponent,
  ],
  providers: [InteractionService],
})
export class InteractionModule { }
