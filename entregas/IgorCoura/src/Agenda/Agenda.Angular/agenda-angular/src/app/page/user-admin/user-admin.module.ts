import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserViewComponent } from './user-view/user-view.component';
import { UserAdminRoutingModule } from './user-admin.routing.module';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { FlexLayoutModule } from '@angular/flex-layout';
import { UserFormComponent } from './user-form/user-form.component';
import { MatSelectModule } from '@angular/material/select';
import { MatOptgroup, MatOptionModule } from '@angular/material/core';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import {MatDialogModule} from '@angular/material/dialog';
import { UserAdminService } from 'src/app/services/user-admin.service';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { AuthAdminGuard } from 'src/app/guards/auth-admin.guard';

@NgModule({
  declarations: [
    UserViewComponent,
    UserFormComponent,
  ],
  imports: [
    CommonModule,
    UserAdminRoutingModule,
    SharedModule,
    MatIconModule,
    MatButtonModule,
    FlexLayoutModule,
    MatSelectModule,
    MatOptionModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatSnackBarModule,
  ],
  providers: [ UserAdminService, AuthAdminGuard ] 
})
export class UserAdminModule { }
