// profile.component.ts
import { Component, OnInit } from '@angular/core';
import { UserService } from '../Services/user.service';
import { BookService } from '../Services/book.service';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import {Book} from '../models/book.model';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  borrowedBooks: number[] = [];
  lentBooks: number[] = [];
  addedBooks: number[] = [];
  tokens: number = 0;
   userId:number=1;

  userborrowedBooks: Book[] = [];
  userlentBooks: Book[] = [];
  useraddedBooks: Book[] = [];
  constructor(private userService: UserService,private bookService:BookService,private router: Router) {}

  ngOnInit(): void {
    // Assuming userId is available, replace it with your actual logic
     // Replace with your logic to get the user id
     const mytoken :any =localStorage.getItem('token');
        const helper = new JwtHelperService();

        const decodedToken = helper.decodeToken(mytoken);
        this.userId = decodedToken.unique_name;

    this.userService.getUserBooksBorrowed(this.userId).subscribe((books) => {
      this.borrowedBooks = books;
      this.fetchBorrowedBooks();
    });

    this.userService.getUserBooksLent(this.userId).subscribe((books) => {
      this.lentBooks = books;
      this.fetchLentBooks();
    });

    this.userService.getUserBooksAdded(this.userId).subscribe((books) => {
      this.addedBooks = books;
      this.fetchAddedBooks();
    });

    this.userService.getUserTokens(this.userId).subscribe((tokens) => {
      this.tokens = tokens;
    });
  }
  fetchBorrowedBooks(): void {
    this.userborrowedBooks = [];
    for (const bookId of this.borrowedBooks) {
      this.bookService.getBookById(bookId).subscribe((book) => {
        this.userborrowedBooks.push(book);
      });
    }
  }
  fetchLentBooks(): void {
    this.userlentBooks = [];
    for (const bookId of this.lentBooks) {
      this.bookService.getBookById(bookId).subscribe((book) => {
        this.userlentBooks.push(book);
      });
    }
  }
  fetchAddedBooks(): void {
    this.useraddedBooks = [];
    for (const bookId of this.addedBooks) {
      this.bookService.getBookById(bookId).subscribe((book) => {
        this.useraddedBooks.push(book);
      });
    }
  }
//   
returnBook(book: Book): void {
  if (book && book.id !== undefined) {
    this.bookService.getBookById(book.id).subscribe((returnedBook) => {
      const ownerId = returnedBook.ownerId;
      // Assuming the service returns the book details
      this.bookService.returnBook(returnedBook.id, this.userId, ownerId).subscribe((message) => {
        console.log(message);
        
        this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
          this.router.navigate(['profile']);
        });
        alert('Book successfully Returned!');// Refresh the borrowed books list
      });
      
    });
  }
}

 logout() {
  // Implement logout functionality here
  // You might want to clear the stored token and navigate to the login page
  localStorage.removeItem('token');
  this.router.navigate(['/login']);
  }
  comeback() {
    // Implement logout functionality here
    // You might want to clear the stored token and navigate to the login page
    
    this.router.navigate(['/dashboard']);
  } 
  addbook(){
    this.router.navigate(['/addbook']);
  }
}

