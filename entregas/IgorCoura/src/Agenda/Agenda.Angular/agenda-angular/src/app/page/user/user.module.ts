import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditComponent } from './edit/edit.component';
import { EditPasswordComponent } from './edit-password/edit-password.component';
import { UserRoutingModule } from './user.routing.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatIconModule } from '@angular/material/icon';
import { UserService } from 'src/app/services/user.service';
import { AuthGuard } from 'src/app/guards/auth.guard';



@NgModule({
  declarations: [
    EditComponent,
    EditPasswordComponent
  ],
  imports: [
    UserRoutingModule,
    CommonModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    MatSnackBarModule,

  ],
  exports:[
    EditComponent,
  ],
  providers: [
    UserService,
    AuthGuard,
  ]
})
export class UserModule { }
