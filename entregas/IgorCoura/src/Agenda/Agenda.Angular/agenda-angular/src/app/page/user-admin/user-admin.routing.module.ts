import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthAdminGuard } from 'src/app/guards/auth-admin.guard';
import { UserFormComponent } from './user-form/user-form.component';
import { UserViewComponent } from './user-view/user-view.component';


const routes: Routes = [
  { path: 'admin/user', children:[
    {path: '', component: UserViewComponent},
    {path: 'form/:id', component: UserFormComponent},
  ], canActivate: [AuthAdminGuard]},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserAdminRoutingModule { }
