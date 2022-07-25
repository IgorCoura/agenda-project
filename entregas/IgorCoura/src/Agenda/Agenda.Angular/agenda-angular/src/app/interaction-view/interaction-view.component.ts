import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-interaction-view',
  templateUrl: './interaction-view.component.html',
  styleUrls: ['./interaction-view.component.scss']
})
export class InteractionViewComponent implements OnInit {

  Interactions = ['a','b','c']

  constructor() { }

  ngOnInit(): void {
  }

}
