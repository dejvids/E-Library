import { Title } from '@angular/platform-browser';
import { title } from 'process';
import {BookType} from './bookType';

export class Book {
    bookId: number;
    bookCopyId: number;
    title: string;
    author: string;
    isbn: string;
    description: string;
    totalCount: number;
    freeCount: number;
    borrowDate: Date;
    type: BookType;

    /**
     *
     */
    constructor(id: number, title: string, author: string) {
        this.bookId = id;
        this. title = title;
        this.author = author;
        
    }
}