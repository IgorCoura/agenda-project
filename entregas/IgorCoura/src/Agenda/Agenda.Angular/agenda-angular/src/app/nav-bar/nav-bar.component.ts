import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  IsAuthenticated : boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  Change(){
    this.IsAuthenticated = !this.IsAuthenticated;
  }

}
