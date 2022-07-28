import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-phone-form',
  templateUrl: './phone-form.component.html',
  styleUrls: ['./phone-form.component.scss']
})
export class PhoneFormComponent implements OnInit {

  @Input() index!: number;
  @Input() phoneForm! : any;
  @Output() removePhone = new EventEmitter(); 

  constructor() { 
    console.log(this.phoneForm);
  }

  ngOnInit(): void {
  }

  remove() { 
    this.removePhone.emit({index: this.index});
  }


}
