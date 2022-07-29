import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactFormComponent } from './contact-form/contact-form.component';
import { ContactViewComponent } from './contact-view/contact-view.component';



const routes: Routes = [
    {path: 'contact', children: [
        { path: '', component: ContactViewComponent },
        { path: 'form/:id', component: ContactFormComponent },
    ]},
    

    {path: 'admin/contact/:userId', children: [
        { path: '', component: ContactViewComponent },
        { path: 'form/:id', component: ContactFormComponent },
    ]},
    

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContactRoutingModule { }
