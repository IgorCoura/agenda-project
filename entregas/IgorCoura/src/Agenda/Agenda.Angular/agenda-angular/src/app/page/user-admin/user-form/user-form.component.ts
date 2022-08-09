import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router} from '@angular/router';
import { UserAdminService } from 'src/app/services/user-admin.service';
import { pipe, Subscription, take } from 'rxjs';
import { UserType } from 'src/app/entities/userType.entity';
import { User } from 'src/app/entities/user.entity';
import { apiErrorHandler } from 'src/app/utils/api-error-handler';
import { BaseFormComponent } from 'src/app/shared/components/base-form/base-form.component';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent extends BaseFormComponent implements OnInit {
  id: number = 0;
  options : UserType[] = [new UserType(1, "Admin"), new UserType(2, "Comum") ] ;
  subscribe!: Subscription;
  title = "Cadastro de Usuário";

  constructor(
    private formBuilder: FormBuilder, 
    private activatedRoute:ActivatedRoute,
    private router : Router,
    private snackBar: MatSnackBar,
    private userAdminService: UserAdminService,
    ) { super(); }
    

  override ngOnInit(): void {

    this.subscribe = this.activatedRoute.params.subscribe(params => {
      this.id = params['id'];
    });

    if(this.id == 0){
      this.title = "Cadastro de Usuário";
      this.form = this.formBuilder.group({
        id: [0],
        userRole: [this.options[0], [Validators.required]],
        userRoleId: [1, [Validators.required]],
        name: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
        userName: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
        email: [null, [Validators.required, Validators.email]],
        password: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(200), Validators.pattern('^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@$_!%*?&-])[0-9a-zA-Z@$_!%*?&-]{8,}$')]],
        confirmPassword: [null, [Validators.required, this.equalsTo('password')]],
      });
      this.isLoading = false;
    }
    else{
      this.title = "Editar Usuário";
      this.form = this.formBuilder.group({
        id: [0],
        userRole: [this.options[0], [Validators.required]],
        userRoleId: [1, [Validators.required]],
        name: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
        userName: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
        email: [null, [Validators.required, Validators.email]],
      });
      this.getUserAsync()
    }
    
  }


  getUserAsync(){
    this.userAdminService.getByIdAsync(this.id)
    .pipe(take(1))
    .subscribe({
      next: (resp) => {
        this.isLoading = false;
        this.form.patchValue(resp.data);
      },
      error: ({error}) => {
        this.isLoading = false;
        apiErrorHandler(this.snackBar, error);
      }
    });
  }

  override submit(){
    if(this.id == 0){
      this.createUser();
    }
    else{
      this.updateUser();
    }
  }


  createUser(){
    let user = this.form.value as User;
    this.userAdminService.createAsync(user)
    .pipe(take(1))
    .subscribe({
      next: (resp) => {
        this.isLoading = false;
        this.snackBar.open("Usuário criado com sucesso", "Fechar", {duration: 3000});
        this.router.navigate(['/admin/user']);
      },
      error: ({error}) => {
        this.isLoading = false;
        apiErrorHandler(this.snackBar, error);
      }
    });
  }

  updateUser(){
    let user = this.form.value as User;
    this.userAdminService.updateAsync(user)
    .pipe(take(1))
    .subscribe({
      next: (resp) => {
        this.isLoading = false;
        this.snackBar.open("Usuário atualizado com sucesso", "Fechar", {duration: 3000});
        this.router.navigate(['/admin/user']);
      },
      error: ({error}) => {
        this.isLoading = false;
        apiErrorHandler(this.snackBar, error);
      }
    });
  }

}