import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactViewComponent } from './contact-view/contact-view.component';
import { MatCardModule } from '@angular/material/card';
import {MatExpansionModule} from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { ContactRoutingModule } from './contact.routing.module';
import { ContactFormComponent } from './contact-form/contact-form.component';
import { PhoneFormComponent } from './phone-form/phone-form.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatDialogModule} from '@angular/material/dialog';


@NgModule({
  declarations: [
    ContactViewComponent,
    ContactFormComponent,
    PhoneFormComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    MatCardModule,
    MatExpansionModule,
    MatIconModule,
    MatButtonModule,
    MatDividerModule,
    ContactRoutingModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatSelectModule,
    MatOptionModule,
    FlexLayoutModule,
    MatDialogModule,
  ],
  exports: [
    ContactViewComponent,
  ]
})
export class ContactModule { }
