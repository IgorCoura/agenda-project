import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Phone } from '../../../entities/phone.entity';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.scss']
})
export class ContactFormComponent implements OnInit {
  form!: FormGroup;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: [null],
      name: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
      phones: this.formBuilder.array([]),
    });
  }

  
  get phonesField(): FormArray {
    return this.form.get('phones') as FormArray;
  }
  

  addPhoneForm(data?: Phone): void {
    this.phonesField.push(
      this.formBuilder.group({
        formattedPhone: [data?.formattedPhone, [Validators.required, Validators.pattern("/^[(]?[1-9][0-9][)]?[ ]?(9?[0-9])[0-9]{3}[-]?[0-9]{4}$/im")]],
        description: [data?.description, [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
        phoneTypeId: [data?.phoneTypeId, [Validators.required]],
      })
    )
  }

  onRemovePhone(event : any){
    this.phonesField.removeAt(event.index);
  }

  onSubmit(){
    console.log("this.form.value");
  }

}
 
