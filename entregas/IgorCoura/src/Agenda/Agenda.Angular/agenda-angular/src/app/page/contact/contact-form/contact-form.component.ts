import { Component, OnInit, OnDestroy , EventEmitter } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription, take } from 'rxjs';
import { Contact } from 'src/app/entities/contact.entity';
import { Phone } from 'src/app/entities/phone.entity';
import { PhoneType } from 'src/app/entities/phoneTypes.entity';
import { ContactService } from 'src/app/services/contact.service';
import { apiErrorHandler } from 'src/app/utils/api-error-handler';

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
  phoneOptions!: PhoneType[];
  
  constructor(
    private formBuilder: FormBuilder, 
    private activatedRoute : ActivatedRoute, 
    private contactService: ContactService, 
    private snackBar : MatSnackBar,
    private router :  Router) { }

  ngOnInit(): void {
    this.subscribe = this.activatedRoute.params.subscribe(params => {
      if(params['id']){
        this.id = params['id'];
      }
      if(params['userId']){
        this.userId = params['userId'];
      }
    });

    this.form = this.formBuilder.group({
      id: [this.id],
      name: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
      phones: this.formBuilder.array([]),
    });
    
    this.getContact();
    this.getPhoneType();

  }

  getPhoneType(){
    this.contactService.getPhoneTypesAsync()
    .pipe(take(1))
    .subscribe({
      next: (resp) => {
        this.phoneOptions = resp.data;
      }
    });
  }


  getContact(){
    if(this.userId === 0 ){     
      this.contactService.getByIdAsync(this.id)
      .pipe(take(1))
      .subscribe({
        next: (resp) => {
          var contact = resp.data;
          this.form.patchValue({
            id: contact.id,
            name: contact.name,
          });
          contact.phones.forEach(phone => {this.addPhoneForm(phone)});
        },
        error: ([error]) => {
          apiErrorHandler(this.snackBar, error);
        }       
      });
    }
  }

  ngOnDestroy(): void {
    this.subscribe.unsubscribe();
  }

  
  get phonesField(): FormArray {
    return this.form.get('phones') as FormArray;
  }
  

  addPhoneForm(data: Phone = new Phone()): void {
    this.phonesField.push(
      this.formBuilder.group({
        id: [data.id],
        formattedPhone: [data?.formattedPhone, [Validators.required, Validators.pattern("/^[(]?[1-9][0-9][)]?[ ]?(9?[0-9])[0-9]{3}[-]?[0-9]{4}$/im")]],
        description: [data?.description, [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
        phoneTypeId: [data?.phoneTypeId, [Validators.required]],
        phoneTye: [data?.phoneType],
      })
    )
  }

  onRemovePhone(event : any){
    this.phonesField.removeAt(event.index);
  }

  onSubmit(){
    if(this.id == 0){
      this.createContact();
    }
    else{
      this.updateContact();
    }

  }

  updateContact(){
    if(this.userId === 0){
      let data = this.form.value as Contact;
      debugger;
      this.contactService.updateAsync(data).subscribe({
        next: (resp) => {
          this.snackBar.open('Contato atualizado com exito', 'fechar', {duration: 2000});
          this.router.navigate(['/']);
        },
        error: ({error}) => {
          apiErrorHandler(this.snackBar, error);
        }
      });
    }
  }

  createContact(){
    if(this.userId === 0){
      let data = this.form.value as Contact;
      this.contactService.createAsync(data).subscribe({
        next: (resp) => {
          this.snackBar.open('Contato criado com exito', 'fechar', {duration: 2000});
          this.router.navigate(['/']);
        },
        error: ({error}) => {
          apiErrorHandler(this.snackBar, error);
        }
      });
    }

  }
 

}
 
