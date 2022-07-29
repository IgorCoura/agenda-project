import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InteractionViewComponent } from './page/interaction/interaction-view/interaction-view.component';

const routes: Routes = [
  {path: '', redirectTo: 'contact', pathMatch: 'full'},
  { path: 'interactions', component: InteractionViewComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
