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
import { RouterModule } from '@angular/router';
import {MatIconModule} from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import {MatListModule} from '@angular/material/list';
import {MatMenuModule} from '@angular/material/menu';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatSelectModule} from '@angular/material/select';



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
    RouterModule,
    MatToolbarModule,
    MatIconModule,
    MatMenuModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    MatSidenavModule,
    MatSnackBarModule,
    MatListModule,
    MatSelectModule,
    FlexLayoutModule,

  ],
  exports: [
    SearchBarComponent,
    NavBarComponent,
    NavPageComponent,
    ContactFormComponent,
  ],
})
export class SharedModule { }
