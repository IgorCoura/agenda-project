import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/guards/auth.guard';
import { EditPasswordComponent } from './edit-password/edit-password.component';
import { EditComponent } from './edit/edit.component';


const routes: Routes = [
    {path: 'user', children: [
        {path: 'edit-password', component: EditPasswordComponent},
        {path: 'edit', component: EditComponent},
    ],
    canActivate: [AuthGuard]
  },
    
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
