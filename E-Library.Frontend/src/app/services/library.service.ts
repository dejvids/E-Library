import { Injectable } from '@angular/core';
import { Book } from '../models/book';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

const baseUrl ='http://localhost:5000/books';
@Injectable({
  providedIn: 'root'
})
export class LibraryService {


  getBorrowed() :Observable<Book[]> {
    return this.http.get<Book[]>(`${baseUrl}/borrowed`);
  }

  constructor(private http: HttpClient) { }

  getAllBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(`${baseUrl}/all`);
  }

  borrowBook(book: Book) {
    return this.http.post(`${baseUrl}/borrow`, book.bookId, { headers: this.GetDefaultHeaders() });
  }

  returnBook(book: Book) : Observable<any> {
    console.log('return');
    return this.http.post(`${baseUrl}/return`, book.bookCopyId, { headers: this.GetDefaultHeaders() });
  }

  getMyWishlist(): Observable<Book[]> {
    return this.http.get<Book[]>(`${baseUrl}/wishlist`);
  }

  addToWishlist(book: Book) :Observable<any> {
   return this.http.post(`${baseUrl}/add-to-wihslist`, book.bookId, { headers: this.GetDefaultHeaders() });
  }

  removeFromWihslist(book: Book) : Observable<any> {
    return this.http.delete(`${baseUrl}/remove-from-wihslist/${book.bookId}`);
  }

  private GetDefaultHeaders() {
    const httpHeaders = new HttpHeaders()
      .set('Content-Type', 'application/json; charset=utf-8')
    return httpHeaders;
  }
}
