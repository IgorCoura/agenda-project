import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { User } from 'src/app/entities/user.entity';
import { UserService } from 'src/app/services/user.service';
import { apiErrorHandler } from 'src/app/utils/api-error-handler';
import { delay, pipe, take, tap } from 'rxjs';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { ConfirmDialogComponent } from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {

  form! : FormGroup;

  constructor(
    private formBuilder : FormBuilder, 
    private userService: UserService, 
    private snackBar: MatSnackBar, 
    private route: Router, 
    private auth: AuthService,
    public dialog: MatDialog,) { }

  ngOnInit(): void {

    this.form = this.formBuilder.group({
      name: [null, []],
      userName: [null, []],
      email: [null, []],
    });

    this.userService.getUserAsync()
    .pipe(take(1))  
    .subscribe((resp) => {
      let user = resp.data;
      this.form.setValue({
        name: user.name,
        userName: user.userName,
        email: user.email,
      });
    });

    
  }

  onSubmit(){
    if(this.form.valid){
      const data = this.form.value as User;
      this.userService.updateAsync(data)
      .pipe(take(1))
      .subscribe({
        next: () => {
          this.snackBar.open("Usuario Atualizado com exito", "Fechar", {
            duration: 3000
          });
          this.route.navigate(['/']);
        },
        error: ({error}) => {
          apiErrorHandler(this.snackBar, error);
        }
      }
      );
    }
  }

  onDelete(){
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '350px',
      data: {title: "Confirmar Exclusão", message: "Deseja realmente excluir o usuário " + this.form.value.name + "?"}
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.userService.deleteUserAsync()
        .pipe(take(1))
        .subscribe({
          next: () => {
            this.auth.clearToken();
            this.route.navigate(['/login']);
          }
        }
        );
      }
    });
  }
}
