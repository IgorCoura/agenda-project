import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './shared/components/nav-bar/nav-bar.component';
import { ContactViewComponent } from './contact-view/contact-view.component';
import { SearchBarComponent } from './shared/components/search-bar/search-bar.component';
import { UserViewComponent } from './user-view/user-view.component';
import { NavPageComponent } from './shared/components/nav-page/nav-page.component';
import { InteractionViewComponent } from './interaction-view/interaction-view.component';
import { ContactFormComponent } from './shared/components/contact-form/contact-form.component';
import { PhoneFormComponent } from './shared/components/phone-form/phone-form.component';
import { LoginComponent } from './login/login.component';
import { SharedModule } from './shared/shared.module';

@NgModule({
  declarations: [
    AppComponent,
    ContactViewComponent,
    UserViewComponent,
    InteractionViewComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
