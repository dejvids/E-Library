import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Filter } from '../models/Filter';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  @Output()
  showBooks = new EventEmitter<Filter>();

  @Input()
  selectedFilter: Filter;

  constructor() { 
    
  }

  ngOnInit(): void {
  }

  getAll() {
    this.showBooks.emit(Filter.All);
  }

  getBorrowed() {
    this.showBooks.emit(Filter.Borrowed);
  }

  getWihslist() {
    this.showBooks.emit(Filter.Wihslist);
  }

}
