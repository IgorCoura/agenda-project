import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { PhoneType } from 'src/app/entities/phoneTypes.entity';

@Component({
  selector: 'app-phone-form',
  templateUrl: './phone-form.component.html',
  styleUrls: ['./phone-form.component.scss']
})
export class PhoneFormComponent implements OnInit {

  @Input() index!: number;
  @Input() phoneForm! : any;
  @Input() options! : PhoneType[];
  @Output() removePhone = new EventEmitter(); 

  constructor() { 
  }

  ngOnInit(): void {
  }

  remove() { 
    this.removePhone.emit({index: this.index});
  }


}
