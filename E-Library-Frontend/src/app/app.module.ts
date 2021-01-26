import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookItemComponent } from './book-item/book-item.component';
import { BooksComponent } from './books/books.component';
import { LibraryService } from './services/library.service';
import { MenuComponent } from './menu/menu.component'

@NgModule({
  declarations: [
    AppComponent,
    BookItemComponent,
    BooksComponent,
    MenuComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [LibraryService],
  bootstrap: [AppComponent]
})
export class AppModule { }
