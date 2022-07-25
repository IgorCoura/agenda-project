import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-view',
  templateUrl: './user-view.component.html',
  styleUrls: ['./user-view.component.scss']
})
export class UserViewComponent implements OnInit {

  Users = ['a', 'b', 'c' ]

  
  constructor() { }


  ngOnInit(): void {
  }

}
