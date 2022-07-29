import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './shared/components/nav-bar/nav-bar.component';
import { SearchBarComponent } from './shared/components/search-bar/search-bar.component';
import { NavPageComponent } from './shared/components/nav-page/nav-page.component';
import { SharedModule } from './shared/shared.module';
import { ContactModule } from './page/contact/contact.module';
import { InteractionModule } from './page/interaction/interaction.module';
import { UserModule } from './page/user/user.module';
import { UserAdminModule } from './page/user-admin/user-admin.module';
import { LoginModule } from './page/login/login.module';



@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    ContactModule,
    InteractionModule,
    UserModule,
    UserAdminModule,
    LoginModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
