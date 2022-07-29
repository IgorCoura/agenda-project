import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.scss']
})
export class RegisterUserComponent implements OnInit {

  form! : FormGroup;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: [0],
      userRole: ["Comum", []],
      userRoleId: [2, []],
      name: [null, []],
      userName: [null, []],
      email: [null, []],
      password: [null, []],
      confirmPassword: [null, []],
    });
  }


  onSubmit() {

  }

}
