import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { User } from 'src/app/entities/user.entity';
import { UserService } from 'src/app/services/user.service';
import { delay, pipe, take, tap } from 'rxjs';
import { apiErrorHandler } from 'src/app/utils/api-error-handler';
import { Router } from '@angular/router';
import { BaseFormComponent } from 'src/app/shared/components/base-form/base-form.component';

@Component({
  selector: 'app-edit-password',
  templateUrl: './edit-password.component.html',
  styleUrls: ['./edit-password.component.scss']
})
export class EditPasswordComponent extends BaseFormComponent implements OnInit {


  constructor(private formBuilder : FormBuilder, private userService: UserService, private snackBar: MatSnackBar, private router : Router) { super() }

  override ngOnInit(): void {

    this.form = this.formBuilder.group({
      password: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(200), Validators.pattern('^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@$_!%*?&-])[0-9a-zA-Z@$_!%*?&-]{8,}$')]],
      confirmPassword: [null, [Validators.required, this.equalsTo('password')]],
    });
    this.isLoading = false;
  }

  override submit(){
    let user = this.form.value as User;
    this.userService.updatePasswordAsync(user)
    .pipe(take(1))
    .subscribe({
      next: () => {
        this.isLoading = false;
        this.snackBar.open("Senha atualizada com exito", "Fechar", {
          duration: 3000
        });
        this.router.navigate(['/']);
      },
      error: ({error}) => {
        this.isLoading = false;
        apiErrorHandler(this.snackBar,error);
      }
    })
  }

}
