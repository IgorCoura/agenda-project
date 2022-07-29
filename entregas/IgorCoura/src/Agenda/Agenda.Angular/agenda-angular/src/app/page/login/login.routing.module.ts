import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginViewComponent } from './login-view/login-view.component';
import { RegisterUserComponent } from './register-user/register-user.component';


const routes: Routes = [
  { path: 'login', children:[
    {path: '', component: LoginViewComponent},
    {path: 'register', component: RegisterUserComponent},
  ]}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoginRoutingModule { }
