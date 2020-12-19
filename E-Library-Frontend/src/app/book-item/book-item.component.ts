import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { Book } from '../models/book';
import { BookType } from '../models/bookType';

@Component({
  selector: 'book-item',
  templateUrl: './book-item.component.html',
  styleUrls: ['./book-item.component.css']
})
export class BookItemComponent implements OnInit {

  // title = "Quovadi";
  // author = "Henryk Sienkiewicz";
  // description = "Bardzo nudna gruba książka";

  @Input()
  book: Book;

  @Output()
  borrowed = new EventEmitter<Book>();

  @Output()
  returned = new EventEmitter<Book>();

  @Output()
  addedToWihslist = new EventEmitter<Book>();

  @Output()
  removedFromWihslist = new EventEmitter<Book>();

  canBeBorrowed :boolean;
  canBeAddToWihslist: boolean;
  canBeReturn: boolean;
  canBeDeleteFromWihslist: boolean;
  isFree: boolean;

  constructor() { }

  ngOnInit(): void {
    this.canBeBorrowed = this.book.type == BookType.Free && this.book.freeCount > 0;
    this.canBeAddToWihslist = this.book.type == BookType.Free;
    this.canBeReturn = this.book.type == BookType.Borrowed;
    this.canBeDeleteFromWihslist = this.book.type == BookType.OnWihslist;
    this.isFree = this.book.type == BookType.Free;
  }

  borrow() {
    this.borrowed.emit(this.book)
  }

  addToWihslist() {
    this.addedToWihslist.emit(this.book);
  }

  returnBook() {
    this.returned.emit(this.book);
  }

  removeFromWihslist() {
    this.removedFromWihslist.emit(this.book);
  }

}
