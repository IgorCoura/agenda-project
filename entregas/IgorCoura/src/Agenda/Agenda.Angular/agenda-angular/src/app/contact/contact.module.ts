import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactViewComponent } from './contact-view/contact-view.component';
import { NavPageComponent } from '../shared/components/nav-page/nav-page.component';
import { SearchBarComponent } from '../shared/components/search-bar/search-bar.component';
import { SharedModule } from '../shared/shared.module';
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
  ],
  exports: [
    ContactViewComponent,
  ]
})
export class ContactModule { }
