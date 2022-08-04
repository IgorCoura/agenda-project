import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { PhoneType } from 'src/app/entities/phoneTypes.entity';
import { BaseFormComponent } from 'src/app/shared/components/base-form/base-form.component';

@Component({
  selector: 'app-phone-form',
  templateUrl: './phone-form.component.html',
  styleUrls: ['./phone-form.component.scss']
})
export class PhoneFormComponent extends BaseFormComponent implements OnInit {
  

  @Input() index!: number;
  @Input() phoneForm! : any;
  @Input() options! : PhoneType[];
  @Output() removePhone = new EventEmitter(); 

  constructor() {  
    super();
  }

  override ngOnInit(): void {
    this.form = this.phoneForm as FormGroup;
  }

  remove() { 
    this.removePhone.emit({index: this.index});
  }

  getMaskPhone(): string {
    return this.form.get("phoneTypeId")?.value === 2
      ? '(00) 00000-0000'
      : '(00) 0000-0000'
  }

  errorMessage(value: string, label: string) {
    var control = this.form.get(value);
    if(control != null){
      for (const propertyName in control!.errors) {
        if (control!.errors.hasOwnProperty(propertyName) &&
        control!.touched) {
            return this.getErrorMsg(label, propertyName, control!.errors[propertyName]);
          }
      }
    }
    return null;
  }

  getErrorMsg(fieldName: string, validatorName: string, validatorValue?: any) {
    const config : {[key: string] : any} = {
      'required': `${fieldName} é obrigatório.`,
      'minlength': `${fieldName} precisa ter no mínimo ${validatorValue.requiredLength} caracteres.`,
      'maxlength': `${fieldName} precisa ter no máximo ${validatorValue.requiredLength} caracteres.`,
      'pattern': 'Campo inválido',
      'mask': 'Telefone inválido. Ex : (00) 0000-0000 ou (00) 90000-0000'
    };

    if(fieldName === 'Telefone' && validatorName === 'pattern'){
      return 'Formato de telefone inválido.';
    }


    return config[validatorName];
  }


}