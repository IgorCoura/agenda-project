import { Component, OnInit, OnDestroy , EventEmitter } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Phone } from 'src/app/entities/phone.entity';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.scss']
})
export class ContactFormComponent implements OnInit, OnDestroy {
  id: number = 0;
  userId: number = 0;
  form!: FormGroup;
  subscribe!: Subscription;
  phoneOptions: Array<string> = ["Residencial", "CellPhone", "Commercial"];
  
  constructor(private formBuilder: FormBuilder, private activatedRoute : ActivatedRoute) { }

  ngOnInit(): void {
    this.subscribe = this.activatedRoute.params.subscribe(params => {
      if(params['id']){
        this.id = params['id'];
      }
      if(params['userId']){
        this.userId = params['userId'];
      }
    });
    if(this.id === 0){
      this.form = this.formBuilder.group({
        id: [this.id],
        name: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
        phones: this.formBuilder.array([]),
      });
    }
    else{
      this.form = this.formBuilder.group({
        id: [this.id],
        name: ["Jose", [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
        phones: this.formBuilder.array([
          this.formBuilder.group({
            formattedPhone: ["(11) 99999-9999", [Validators.required, Validators.pattern("/^[(]?[1-9][0-9][)]?[ ]?(9?[0-9])[0-9]{3}[-]?[0-9]{4}$/im")]],
            description: ["description", [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
            phoneTypeId: ["Cellphone", [Validators.required]],
            phoneType: ["Cellphone"],
          })
        ]),
      });
    }
  }

  ngOnDestroy(): void {
    this.subscribe.unsubscribe();
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
        phoneTye: ["CellPhone"],
      })
    )
  }

  onRemovePhone(event : any){
    this.phonesField.removeAt(event.index);
  }

  onSubmit(){
  }

}
 
