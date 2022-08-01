import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { User } from 'src/app/entities/user.entity';
import { AuthService } from 'src/app/services/auth.service';
import { UserService } from 'src/app/services/user.service';
import { apiErrorHandler } from 'src/app/utils/api-error-handler';
import { delay, pipe, take } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.scss']
})
export class RegisterUserComponent implements OnInit {

  form! : FormGroup;
  isLoading = false;

  constructor(private formBuilder: FormBuilder, private userService: UserService, private snackBar: MatSnackBar, private router : Router) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: [0],
      userRole: ["Comum", []],
      userRoleId: [2, []],
      name: [null, [Validators.required]],
      userName: [null, []],
      email: [null, []],
      password: [null, []],
      confirmPassword: [null, []],
    });
  }

  applyCssError(control: string) {
    return{
      "is-invalid": this.verifyIsTouched(control)
    }
  }

  verifyIsTouched(control: string) {
    return this.form.get(control)!.touched && this.form.get(control)!.invalid;
  }


  onSubmit() {
    this.isLoading = true;
    if(this.form.valid){
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
    else{
      this.isLoading = false;
    }
  }
}
