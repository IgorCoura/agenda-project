import { Component, OnInit } from '@angular/core';
import { Interaction } from 'src/app/entities/interaction.entity';

@Component({
  selector: 'app-interaction-view',
  templateUrl: './interaction-view.component.html',
  styleUrls: ['./interaction-view.component.scss']
})
export class InteractionViewComponent implements OnInit {

  interactions = [new Interaction(1, 1, "InteractionType", "Message"), new Interaction(2, 2, "InteractionType2", "Message2"),]
  
  constructor() { }

  ngOnInit(): void {
  }

}
