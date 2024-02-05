// book.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'https://localhost:7084'; // Replace with your actual API URL

  constructor(private http: HttpClient) {}
  login(username: string, password: string): Observable<any> {
    const loginUrl = `${this.apiUrl}/api/users/login`;

    // Assuming your backend expects a JSON payload
    const body = { username, password };

    return this.http.post(loginUrl, body);
  }

  getUserTokens(userId: number): Observable<number> {
    return this.http.get<number>(`${this.apiUrl}/api/users/${userId}/available-tokens`);
  }

  getUserBooksBorrowed(userId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/api/users/${userId}/books-borrowed`);
  }

  getUserBooksLent(userId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/api/users/${userId}/books-lent`);
  }

  getUserBooksAdded(userId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/api/users/${userId}/books-added`);
  }
}
