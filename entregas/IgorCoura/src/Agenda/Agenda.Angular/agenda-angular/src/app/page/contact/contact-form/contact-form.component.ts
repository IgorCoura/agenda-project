import { Component, OnInit, OnDestroy , EventEmitter } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription, take } from 'rxjs';
import { Contact } from 'src/app/entities/contact.entity';
import { Phone } from 'src/app/entities/phone.entity';
import { PhoneType } from 'src/app/entities/phoneTypes.entity';
import { ContactAdminService } from 'src/app/services/contact-admin.service';
import { ContactService } from 'src/app/services/contact.service';
import { BaseFormComponent } from 'src/app/shared/components/base-form/base-form.component';
import { apiErrorHandler } from 'src/app/utils/api-error-handler';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.scss']
})
export class ContactFormComponent extends BaseFormComponent implements OnInit, OnDestroy {
  id: number = 0;
  userId: number = 0;
  subscribe!: Subscription;
  phoneOptions!: PhoneType[];
  
  constructor(
    private formBuilder: FormBuilder, 
    private activatedRoute : ActivatedRoute, 
    private contactService: ContactService, 
    private snackBar : MatSnackBar,
    private router :  Router,
    private contactAdminService: ContactAdminService,
    ) { super(); }

  override ngOnInit(): void {
    this.subscribe = this.activatedRoute.params.subscribe(params => {
      if(params['id']){
        this.id = params['id'];
      }
      if(params['userId']){
        this.userId = params['userId'];
      }
    });

    this.form = this.formBuilder.group({
      id: [null],
      name: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
      phones: this.formBuilder.array([]),
    });
    
    if(this.id != 0){
      this.getContact();
    }
    else{
      this.isLoading = false;
    }
    
    this.getPhoneType();

  }


  getPhoneType(){
    this.contactService.getPhoneTypesAsync()
    .pipe(take(1))
    .subscribe({
      next: (resp) => {
        this.phoneOptions = resp.data;
      },
      error: ({error}) => {
        apiErrorHandler(this.snackBar, error);
      }
    });
  }


  getContact(){
    if(this.userId === 0 ){     
      this.contactService.getByIdAsync(this.id)
      .pipe(take(1))
      .subscribe({
        next: (resp) => {
          this.isLoading = false;
          var contact = resp.data;
          this.form.patchValue({
            id: contact.id,
            name: contact.name,
          });
          contact.phones.forEach(phone => {this.addPhoneForm(phone)});
        },
        error: ({error}) => {
          this.isLoading = false;
          apiErrorHandler(this.snackBar, error);
        }     
      });
    }
    else{
      this.contactAdminService.getByIdAsync(this.id, this.userId)
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
        error: ({error}) => {
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
        formattedPhone: [data?.formattedPhone, [Validators.required]],
        description: [data?.description, [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
        phoneTypeId: [data?.phoneTypeId, [Validators.required]],
        phoneTye: [data?.phoneType],
      })
    )
  }

  //Validators.pattern("/^[(]?[1-9][0-9][)]?[ ]?(9?[0-9])[0-9]{3}[-]?[0-9]{4}$/im")

  onRemovePhone(event : any){
    this.phonesField.removeAt(event.index);
  }

  override submit(){
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
    else{
      let data = this.form.value as Contact;
      this.contactAdminService.updateAsync(data, this.userId).subscribe({
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
    else{
      let data = this.form.value as Contact;
      this.contactAdminService.createAsync(data, this.userId).subscribe({
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
 
