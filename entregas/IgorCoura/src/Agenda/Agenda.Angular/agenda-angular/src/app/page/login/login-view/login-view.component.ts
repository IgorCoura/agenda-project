import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { delay, pipe, take } from 'rxjs';
import { Login } from 'src/app/entities/login.entity';
import { AuthService } from 'src/app/services/auth.service';
import { apiErrorHandler } from 'src/app/utils/api-error-handler';

@Component({
  selector: 'app-login-view',
  templateUrl: './login-view.component.html',
  styleUrls: ['./login-view.component.scss']
})
export class LoginViewComponent implements OnInit {

  form! : FormGroup;
  isLoading = false;

  constructor (private formBuider: FormBuilder, private auth: AuthService, private route: Router, private snackBar: MatSnackBar,) { }

  ngOnInit(): void {
    this.form = this.formBuider.group({
      userName: [null, [Validators.required]],
      password: [null, [Validators.required]],
    });
  }



  submit(){
    this.isLoading = true;
    if(this.form.valid){
      const data = this.form.value as Login;
      const response = this.auth.loginAsync(data)
      .pipe(take(1))
      .subscribe({
        next: (resp) => {
          this.isLoading = false;
          this.route.navigate(['/']);   
        },
        error: ({error}) => {
          apiErrorHandler(this.snackBar, error);
          this.isLoading = false;
        }
      });
    }
    else{
      this.isLoading = false;
    }
  }

}
