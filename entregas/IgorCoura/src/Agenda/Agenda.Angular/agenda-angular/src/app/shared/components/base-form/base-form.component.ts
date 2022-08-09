import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-base-form',
  template: '<div></div>',
})
export abstract class BaseFormComponent implements OnInit {

  form! : FormGroup;
  isLoading = true;

  constructor() { }

  ngOnInit() {
  }

  submit() : void{};

  onSubmit() {
    this.isLoading = true;
    if(this.form.valid){
      this.submit();
    }
    else{
      this.isLoading = false;
      this.verifyValidateForm(this.form);
    }
  }

  
  applyCssError(control: string) {
    return{
      "is-invalid":  this.verifyIsTouched(control)
    }
  }

  verifyIsTouched(control: string) {
    return  this.form.get(control)!.touched &&  this.form.get(control)!.invalid;;
  }

  verifyValidateForm(formGroup: FormGroup | FormArray) {
    Object.keys(formGroup.controls).forEach(camp => {
      const control = formGroup.get(camp);
      control!.markAsDirty();
      control!.markAsTouched();
      if (control instanceof FormGroup || control instanceof FormArray) {
        this.verifyValidateForm(control);
      }
    });
  }

  equalsTo(otherField: string) {
    const validator = (formControl: FormControl) => {
      if (otherField == null) {
        throw new Error('É necessário informar um campo.');
      }

      if (!formControl.root || !(<FormGroup>formControl.root).controls) {
        return null;
      }

      const field = (<FormGroup>formControl.root).get(otherField);

      if (!field) {
        throw new Error('É necessário informar um campo válido.');
      }

      if (field.value !== formControl.value) {
        return { equalsTo : otherField };
      }

      return null;
    };
    return validator;
  }

  validatePhone() {
    const validator = (formControl: FormControl) => {
      if (!formControl.root || !(<FormGroup>formControl.root).controls) {
        return null;
      }
      const isValid = new RegExp(/^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}/).test(formControl.value);
      if (isValid) {
        return { validatePhone : "validatePhone" };
      }
      return null;
    };
    return validator;
  }

 

}
