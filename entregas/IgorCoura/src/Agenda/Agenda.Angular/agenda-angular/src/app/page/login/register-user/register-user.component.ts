import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { User } from 'src/app/entities/user.entity';
import { AuthService } from 'src/app/services/auth.service';
import { UserService } from 'src/app/services/user.service';
import { apiErrorHandler } from 'src/app/utils/api-error-handler';
import { delay, pipe, take } from 'rxjs';
import { Router } from '@angular/router';
import { BaseFormComponent } from 'src/app/shared/components/base-form/base-form.component';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.scss']
})
export class RegisterUserComponent extends BaseFormComponent implements OnInit {

  

  constructor(private formBuilder: FormBuilder, private userService: UserService, private snackBar: MatSnackBar, private router : Router) {
    super();
   }

  override ngOnInit(): void {

    this.form = this.formBuilder.group({
      id: [0],
      userRole: ["Comum", []],
      userRoleId: [2, []],
      name: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
      userName: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(200), Validators.pattern('^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@$_!%*?&-])[0-9a-zA-Z@$_!%*?&-]{8,}$')]],
      confirmPassword: [null, [Validators.required, this.equalsTo('password')]],
    });
    this.isLoading = false;
  }



  override submit() {
    const data = this.form.value as User;
    const a = this.userService.createAsync(data)
    .pipe(take(1))
    .subscribe({
      next: (resp) => {
        this.isLoading = false;
        this.router.navigate(['/login']);
      },
      error: ({error}) => {
        this.isLoading = false;
        apiErrorHandler(this.snackBar, error);
      }
    })
  }


}
