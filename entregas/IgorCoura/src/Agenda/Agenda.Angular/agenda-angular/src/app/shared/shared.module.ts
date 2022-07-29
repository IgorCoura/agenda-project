import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchBarComponent } from './components/search-bar/search-bar.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { NavPageComponent } from './components/nav-page/nav-page.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FormDebugComponent } from './components/form-debug/form-debug.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import { RouterModule } from '@angular/router';
import {MatIconModule} from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import {MatListModule} from '@angular/material/list';
import {MatMenuModule} from '@angular/material/menu';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatSelectModule} from '@angular/material/select';
import {MatPaginatorModule} from '@angular/material/paginator';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';
import {MatDialogModule} from '@angular/material/dialog';


@NgModule({
  declarations: [
    SearchBarComponent,
    NavBarComponent,
    NavPageComponent,
    FormDebugComponent,
    ConfirmDialogComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MatToolbarModule,
    MatIconModule,
    MatMenuModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    MatSidenavModule,
    MatSnackBarModule,
    MatListModule,
    MatSelectModule,
    FlexLayoutModule,
    MatPaginatorModule,
    MatDialogModule,
  ],
  exports: [
    SearchBarComponent,
    NavBarComponent,
    FormDebugComponent,
    NavPageComponent,
    ConfirmDialogComponent,
  ],
})
export class SharedModule { }
