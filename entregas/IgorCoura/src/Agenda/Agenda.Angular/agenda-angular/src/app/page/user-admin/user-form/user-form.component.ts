import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {
  id: number = 0;
  options = ["Admin", "Comum"];
  subscribe!: Subscription;
  form! : FormGroup;
  title = "Cadastro de Usuário";

  constructor(private formBuilder: FormBuilder, private activatedRoute:ActivatedRoute) { }

  ngOnInit(): void {

    this.subscribe = this.activatedRoute.params.subscribe(params => {
      this.id = params['id'];
    });

    if(this.id == 0){
      this.title = "Cadastro de Usuário";
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
    }
    else{
      this.title = "Editar Usuário";
      this.form = this.formBuilder.group({
        id: [this.id],
        userRole: ["Comum", []],
        name: ["Jose", []],
        userName: ["jose", []],
        email: ["jose@email.com", []],
        userRoleId: [2, []],
      });
    }
    
  }

  onSubmit(){
    console.log(this.form);
  }


}