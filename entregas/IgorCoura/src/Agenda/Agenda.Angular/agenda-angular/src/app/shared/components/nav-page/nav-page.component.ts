import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-nav-page',
  templateUrl: './nav-page.component.html',
  styleUrls: ['./nav-page.component.scss']
})
export class NavPageComponent implements OnInit {

  @Input() length: number = 100;
  @Input() pageSize: number = 10;
  @Input() pageSizeOptions = [5, 10, 25];
  @Output() changePageEvent = new EventEmitter();


  constructor() { }

  ngOnInit(): void {
  }

  handlePageEvent(event: PageEvent) {
    this.length = event.length;
    this.pageSize = event.pageSize;
    this.changePageEvent.emit({take: event.pageSize, skip: this.pageSize * event.pageIndex});
  }


}
