import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contact-view',
  templateUrl: './contact-view.component.html',
  styleUrls: ['./contact-view.component.scss']
})
export class ContactViewComponent implements OnInit {

contacts = ["a", "b", "c" ] 
  constructor() { }

  ngOnInit(): void {
  }

}
