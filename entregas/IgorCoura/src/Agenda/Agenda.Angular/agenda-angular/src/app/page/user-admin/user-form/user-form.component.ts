import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router} from '@angular/router';
import { UserAdminService } from 'src/app/services/user-admin.service';
import { pipe, Subscription, take } from 'rxjs';
import { UserType } from 'src/app/entities/userType.entity';
import { User } from 'src/app/entities/user.entity';
import { apiErrorHandler } from 'src/app/utils/api-error-handler';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {
  id: number = 0;
  options : UserType[] = [new UserType(1, "Admin"), new UserType(2, "Comum") ] ;
  subscribe!: Subscription;
  form! : FormGroup;
  title = "Cadastro de Usuário";

  constructor(
    private formBuilder: FormBuilder, 
    private activatedRoute:ActivatedRoute,
    private router : Router,
    private snackBar: MatSnackBar,
    private userAdminService: UserAdminService,
    ) { }
    

  ngOnInit(): void {

    this.subscribe = this.activatedRoute.params.subscribe(params => {
      this.id = params['id'];
    });

    this.form = this.formBuilder.group({
      id: [this.id],
      userRole: [this.options[0], []],
      name: [null, []],
      userName: [null, []],
      email: [null, []],
      userRoleId: [null, []],
      password: [null, []],
      confirmPassword: [null, []],
    });

    if(this.id == 0){
      this.title = "Cadastro de Usuário";
    }
    else{
      this.title = "Editar Usuário";
      this.getUserAsync()
    }
    
  }


  getUserAsync(){
    this.userAdminService.getByIdAsync(this.id)
    .pipe(take(1))
    .subscribe({
      next: (resp) => {
        this.form.patchValue(resp.data);
      },
      error: ({error}) => {
        apiErrorHandler(this.snackBar, error);
      }
    });
  }

  onSubmit(){
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
        this.snackBar.open("Usuário criado com sucesso", "Fechar", {duration: 3000});
        this.router.navigate(['/admin/user']);
      },
      error: ({error}) => {
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
        this.snackBar.open("Usuário atualizado com sucesso", "Fechar", {duration: 3000});
        this.router.navigate(['/admin/user']);
      },
      error: ({error}) => {
        apiErrorHandler(this.snackBar, error);
      }
    });
  }

}