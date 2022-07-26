import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchBarComponent } from './components/search-bar/search-bar.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { NavPageComponent } from './components/nav-page/nav-page.component';
import { ContactFormComponent } from './components/contact-form/contact-form.component';
import { PhoneFormComponent } from './components/phone-form/phone-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FormDebugComponent } from './components/form-debug/form-debug.component';
import {MatToolbarModule} from '@angular/material/toolbar';



@NgModule({
  declarations: [
    SearchBarComponent,
    NavBarComponent,
    NavPageComponent,
    ContactFormComponent,
    PhoneFormComponent,
    FormDebugComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatToolbarModule
  ],
  exports: [
    SearchBarComponent,
    NavBarComponent,
    NavPageComponent,
    ContactFormComponent,
  ],
})
export class SharedModule { }
