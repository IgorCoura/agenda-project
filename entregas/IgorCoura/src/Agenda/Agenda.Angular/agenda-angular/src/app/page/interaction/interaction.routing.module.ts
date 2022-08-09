import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthAdminGuard } from "src/app/guards/auth-admin.guard";
import { InteractionViewComponent } from "./interaction-view/interaction-view.component";

const routes: Routes = [
    {path: 'interactions', children: [
        { path: '', component: InteractionViewComponent},
    ], canActivate: [AuthAdminGuard]},

    

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InteractionRoutingModule { }
