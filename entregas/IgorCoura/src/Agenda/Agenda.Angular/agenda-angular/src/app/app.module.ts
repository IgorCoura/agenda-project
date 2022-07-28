import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './shared/components/nav-bar/nav-bar.component';
import { ContactViewComponent } from './contact/contact-view/contact-view.component';
import { SearchBarComponent } from './shared/components/search-bar/search-bar.component';
import { UserViewComponent } from './user-admin/user-view/user-view.component';
import { NavPageComponent } from './shared/components/nav-page/nav-page.component';
import { InteractionViewComponent } from './interaction/interaction-view/interaction-view.component';
import { ContactFormComponent } from './contact/contact-form/contact-form.component';
import { PhoneFormComponent } from './contact/phone-form/phone-form.component';
import { LoginComponent } from './login/login.component';
import { SharedModule } from './shared/shared.module';
import { ContactModule } from './contact/contact.module';
import { InteractionModule } from './interaction/interaction.module';
import { UserModule } from './user/user.module';
import { UserAdminModule } from './user-admin/user-admin.module';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    ContactModule,
    InteractionModule,
    UserModule,
    UserAdminModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
