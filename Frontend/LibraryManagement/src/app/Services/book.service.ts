// book.service.ts

import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../models/book.model';
@Injectable({
  providedIn: 'root'
})
export class BookService {
  private apiUrl = 'https://localhost:7084'; // Replace with your actual API URL

  constructor(private http: HttpClient) {}

  getAllBooks(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/api/books`);
  }
  addBook(book: Book): Observable<Book> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Book>(`${this.apiUrl}/api/books`, JSON.stringify(book), { headers });
  }
  getAvailableBooks(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/api/books/available`);
  }
  getAvailableBooksUser(userId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/api/books/availablebooks?userId=${userId}`);
  }
  getBookById(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/api/books/${id}`);
  }

  editBook(id: number, data: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/api/books/${id}`, data);
  }

  deleteBook(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/api/books/${id}`);
  }

  borrowBook(bookId: number, lenderId: number,borrowerId: number): Observable<string> {
    return this.http.post(`${this.apiUrl}/api/books/borrow/${bookId}/${lenderId}/${borrowerId}`, {},{ responseType: 'text' });
  }

  returnBook(bookId: number,borrowerId:number,ownerId:number): Observable<string> {
    return this.http.post(`${this.apiUrl}/api/books/return/${bookId}/${borrowerId}/${ownerId}`, {},{ responseType: 'text' });
  }

}
