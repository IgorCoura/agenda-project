import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/entities/user.entity';

@Component({
  selector: 'app-user-view',
  templateUrl: './user-view.component.html',
  styleUrls: ['./user-view.component.scss']
})
export class UserViewComponent implements OnInit {

  optionsSearch: Array<string> = ["Name", "Email", "Username"];
  Users = [
    new User(1, "Comum", "Jose", "jose", "jose@email.com", 1, "12345667", "12345667"),
    new User(1, "Comum", "Maria", "Maria", "Maria@email.com", 1, "12345667", "12345667"),
  ]


  constructor() { }


  ngOnInit(): void {
  }

  onSearch(event: any) {
    console.log(event.option + " " + event.search);
  }

  onAdd() {
    console.log("Add");
  }

}
