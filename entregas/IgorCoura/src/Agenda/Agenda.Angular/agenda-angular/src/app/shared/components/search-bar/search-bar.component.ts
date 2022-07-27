import { Component, Input, OnInit, Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss']
})
export class SearchBarComponent implements OnInit {

  @Input() optionsSearch : Array<string> = ["DDD", "Nome", "Telefone"];
  @Output() searchEvent = new EventEmitter();
  @Output() addEvent = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  onSearch(){

  }

  onAdd(){

  }


}
