import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { User } from 'src/app/entities/user.entity';
import { UserService } from 'src/app/services/user.service';
import { delay, pipe, take, tap } from 'rxjs';
import { apiErrorHandler } from 'src/app/utils/api-error-handler';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-password',
  templateUrl: './edit-password.component.html',
  styleUrls: ['./edit-password.component.scss']
})
export class EditPasswordComponent implements OnInit {

  form! : FormGroup;

  constructor(private formBuilder : FormBuilder, private userService: UserService, private snackBar: MatSnackBar, private router : Router) { }

  ngOnInit(): void {

    this.form = this.formBuilder.group({
      password: [null, []],
      confirmPassword: [null, []],
    });

  }

  onSubmit(){
    let user = this.form.value as User;
    this.userService.updatePasswordAsync(user)
    .pipe(take(1))
    .subscribe({
      next: () => {
        this.snackBar.open("Senha atualizada com exito", "Fechar", {
          duration: 3000
        });
        this.router.navigate(['/']);
      },
      error: ({error}) => {
        apiErrorHandler(this.snackBar,error);
      }
    })
  }

}
