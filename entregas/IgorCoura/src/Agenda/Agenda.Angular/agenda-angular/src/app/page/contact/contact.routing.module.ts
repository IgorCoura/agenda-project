import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthAdminGuard } from 'src/app/guards/auth-admin.guard';
import { AuthGuard } from 'src/app/guards/auth.guard';
import { ContactFormComponent } from './contact-form/contact-form.component';
import { ContactViewComponent } from './contact-view/contact-view.component';



const routes: Routes = [
    {path: 'contact', children: [
        { path: '', component: ContactViewComponent },
        { path: 'form/:id', component: ContactFormComponent },
    ], canActivate: [AuthGuard]},
    

    {path: 'admin/contact/:userId', children: [
        { path: '', component: ContactViewComponent },
        { path: 'form/:id', component: ContactFormComponent },
    ], canActivate: [AuthAdminGuard]},
    

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContactRoutingModule { }
