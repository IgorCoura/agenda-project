import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InteractionViewComponent } from './interaction-view/interaction-view.component';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { InteractionService } from 'src/app/services/interaction.service';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { InteractionRoutingModule } from './interaction.routing.module';
import { AuthAdminGuard } from 'src/app/guards/auth-admin.guard';



@NgModule({
  declarations: [
    InteractionViewComponent,
  ],
  imports: [
    MatListModule,
    CommonModule,
    MatCardModule,
    MatSnackBarModule,
    InteractionRoutingModule,
  ],
  exports: [
    InteractionViewComponent,
  ],
  providers: [InteractionService, AuthAdminGuard],
})
export class InteractionModule { }
