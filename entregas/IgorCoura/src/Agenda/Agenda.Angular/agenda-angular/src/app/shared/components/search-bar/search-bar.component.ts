import { Component, Input, OnInit, Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss']
})
export class SearchBarComponent implements OnInit {

  @Input() optionsSearch : Array<string> = [];
  @Output() searchEvent = new EventEmitter();
  @Output() addEvent = new EventEmitter();
  selectedOption!: string;

  constructor() { }

  ngOnInit(): void {
    this.selectedOption = this.optionsSearch[0];
  }

  onSearch(search: string){
    this.searchEvent.emit({option: this.selectedOption,  search: search});
  }

  onAdd(){
    this.addEvent.emit();
  }


  


}
