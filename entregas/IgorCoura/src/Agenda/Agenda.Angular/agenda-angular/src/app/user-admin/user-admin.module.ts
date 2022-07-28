import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserViewComponent } from './user-view/user-view.component';
import { UserAdminRoutingModule } from './user-admin.routing.module';
import { SharedModule } from '../shared/shared.module';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { FlexLayoutModule } from '@angular/flex-layout';



@NgModule({
  declarations: [
    UserViewComponent,
  ],
  imports: [
    CommonModule,
    UserAdminRoutingModule,
    SharedModule,
    MatIconModule,
    MatButtonModule,
    FlexLayoutModule,
  ]
})
export class UserAdminModule { }
