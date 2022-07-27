import { Component, OnInit } from '@angular/core';
import { Contact } from 'src/app/entities/contact.entity';
import { Phone } from 'src/app/entities/phone.entity';

@Component({
  selector: 'app-contact-view',
  templateUrl: './contact-view.component.html',
  styleUrls: ['./contact-view.component.scss']
})
export class ContactViewComponent implements OnInit {

  contacts = [new Contact(1, "Jose", [new Phone(1, "123456789", "Home", 1, "Celular"), new Phone(2, "123456789", "Home", 1, "Celular")]), new Contact(1, "Maria", [new Phone(1, "123456789", "Home", 1, "Celular"), new Phone(2, "123456789", "Home", 1, "Celular")]),];

  constructor() { }

  ngOnInit(): void {
  }

  onEdit(){

  }

  onDelete(){
    
  }

}
