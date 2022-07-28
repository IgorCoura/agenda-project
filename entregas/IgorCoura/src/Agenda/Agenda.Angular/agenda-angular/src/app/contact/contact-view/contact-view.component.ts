import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Contact } from 'src/app/entities/contact.entity';
import { Phone } from 'src/app/entities/phone.entity';

@Component({
  selector: 'app-contact-view',
  templateUrl: './contact-view.component.html',
  styleUrls: ['./contact-view.component.scss']
})
export class ContactViewComponent implements OnInit {

  contacts = [new Contact(1, "Jose", [new Phone(1, "123456789", "Home", 1, "Celular"), new Phone(2, "123456789", "Home", 1, "Celular")]), new Contact(2, "Maria", [new Phone(1, "123456789", "Home", 1, "Celular"), new Phone(2, "123456789", "Home", 1, "Celular")]),];

  optionsSearch : Array<string> = ["Name", "Phone", "DDD"];


  constructor(private router : Router, private activatedRoute : ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      console.log(params);
    });
  }


  onDelete(){
    
  }

  onSearch(event : any){
    console.log(event.option + " " + event.search);
  }

  onAdd(){
    this.router.navigate(['/contact/form/0']);
  }

}
