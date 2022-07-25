import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { ContactViewComponent } from './contact-view/contact-view.component';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { UserViewComponent } from './user-view/user-view.component';
import { NavPageComponent } from './nav-page/nav-page.component';
import { InteractionViewComponent } from './interaction-view/interaction-view.component';
import { ContactFormComponent } from './contact-form/contact-form.component';
import { PhoneFormComponent } from './phone-form/phone-form.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    ContactViewComponent,
    SearchBarComponent,
    UserViewComponent,
    NavPageComponent,
    InteractionViewComponent,
    ContactFormComponent,
    PhoneFormComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
