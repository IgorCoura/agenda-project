import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactViewComponent } from './contact/contact-view/contact-view.component';
import { InteractionViewComponent } from './interaction/interaction-view/interaction-view.component';
import { ContactFormComponent } from './contact/contact-form/contact-form.component';
import { EditComponent } from './user/edit/edit.component';

const routes: Routes = [
  {path: '', redirectTo: 'contact', pathMatch: 'full'},
  { path: 'interactions', component: InteractionViewComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
