import { Component, forwardRef, Input } from '@angular/core';
import { AbstractControl, ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR } from '@angular/forms';


const INPUT_FIELD_VALUE_ACCESSOR: any = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => InputFieldComponent),
  multi: true
};

@Component({
  selector: 'app-input-field',
  templateUrl: './input-field.component.html',
  styleUrls: ['./input-field.component.scss'],
  providers: [INPUT_FIELD_VALUE_ACCESSOR]
})
export class InputFieldComponent implements ControlValueAccessor {

  @Input() id!: string;
  @Input() typeLabel = "collumn";
  @Input() label!: string;
  @Input() type: string = "text";
  @Input() placeholder: string = "Insira o texto";
  @Input() control!: AbstractControl | null;
  @Input() applyCss! : any;
  @Input() isReadOnly = false;

  private innerValue: any;

  get value() {
    return this.innerValue;
  }

  set value(v: any) {
    if (v !== this.innerValue) {
      this.innerValue = v;
      this.onChange(v);
    }
  }

  constructor() { }

  onChange: (_: any) => void = () => {};
  onTouched: () => void = () => {};

  writeValue(v: any): void {
    this.value = v;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState?(isDisabled: boolean): void {
    this.isReadOnly = isDisabled;
  }


  get errorMessage() {
    if(this.control != null){
      for (const propertyName in this.control!.errors) {
        if (this.control!.errors.hasOwnProperty(propertyName) &&
          this.control!.touched) {
            return this.getErrorMsg(this.label, propertyName, this.control!.errors[propertyName]);
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
      'email': 'Formato de email invalido.',
      'emailInvalido': 'Email já cadastrado!',
      'equalsTo': 'Campos não são iguais',
      'pattern': 'Campo inválido'
    };

    if(fieldName === 'Senha' && validatorName === 'pattern'){
      return 'Senha deve conter o mínimo de oito caracteres, pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.';
    }

    return config[validatorName];
  }

}
