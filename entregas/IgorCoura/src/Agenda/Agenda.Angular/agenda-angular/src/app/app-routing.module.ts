import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactViewComponent } from './contact/contact-view/contact-view.component';
import { InteractionViewComponent } from './interaction/interaction-view/interaction-view.component';

const routes: Routes = [
  {path: '', redirectTo: 'contact', pathMatch: 'full'},
  { path: 'contact', component: ContactViewComponent },
  { path: 'interactions', component: InteractionViewComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
