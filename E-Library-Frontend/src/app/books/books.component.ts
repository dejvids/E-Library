import { Component, OnInit } from '@angular/core';
import { LibraryService } from '../services/library.service';
import { Book } from '../models/book';
import { BookType } from '../models/bookType';
import { catchError } from 'rxjs/operators';
import { Observable, of, throwError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  books: Array<Book>;
  message:string;
  error: string;
  isAlertVisible: boolean;
  isErrorAlertVisible: boolean;

  constructor(private library: LibraryService) { }

  ngOnInit(): void {
   this.getAll();
  }

  hideAlert() {
    this.isAlertVisible = false;
    this.message = "";
  }

  showAlert(message: string) {
    this.message = message;
    this.isAlertVisible = true;
  }

  showErrorAler(message){
    this.error = message;
    this.isErrorAlertVisible = true;
  }

  onBorrowed(book:Book) {
    this.library.borrowBook(book)
    .subscribe(_=> { 
      this.showAlert("Wypożyczono"); 
      this.getAll();
    });
  }

  onReturned(book:Book) {
    this.library.returnBook(book)
    .subscribe(_=> {
      this.showAlert("Zwrócono");
      this.getBorrowed();
    });
  }

  onAddedToWihslist(book:Book) {
    this.library.addToWishlist(book)
    .pipe(catchError(this.handleError))
    .subscribe(_=> {
      this.showAlert("Dodano do listy");
    })
  }

  onRemovedFromWihslist(book:Book) {
    this.library.removeFromWihslist(book)
    .subscribe(_ => {
      this.showAlert("Usunięto z listy");
      this.getWihslist();
    })
  }

  getBorrowed() {
    this.library.getBorrowed()
    .subscribe(res =>  {
      res.forEach(b => b.type = BookType.Borrowed);
      this.books = res;
    });
  }

  getWihslist() {
    this.library.getMyWishlist()
    .subscribe(res => {
      res.forEach(b => b.type = BookType.OnWihslist);
      this.books = res;
    });
  }

  getAll() {
    this.library.getAllBooks()
    .subscribe(res => {
      res.forEach(b => b.type = BookType.Free);
      this.books = res;
    });
  }

  private handleError(error: HttpErrorResponse) {
    console.log(error.error);
    this.showAlert(error.error);
      
      return throwError(
        'Ups something went wrong :(');
  }
}
