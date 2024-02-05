// home.component.ts

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from '../Services/book.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  books: any[] = [];
  isLoggedIn:boolean=false;
  searchTerm: string = '';
  displayedBooks: any[] = [];
  constructor(private router: Router, private bookService: BookService) { }

  ngOnInit(): void {
    // Fetch books when the component is initialized
    const mytoken :any =localStorage.getItem('token');
        const helper = new JwtHelperService();

        const decodedToken = helper.decodeToken(mytoken);
        if(decodedToken){
          this.isLoggedIn==true;
        }
    this.fetchBooks();
  }

  fetchBooks() {
    // Call the BookService to get all books
    this.bookService.getAllBooks().subscribe(
      data => {
        this.books = data;
      },
      error => {
        console.error('Error fetching books', error);
      }
    );
  }

  onBorrowClick(bookId: number) {
    // Check if the user is logged in
     

    if (this.isLoggedIn) {
      // Navigate to the borrow page or perform borrowing logic
      console.log(`Borrowing book with ID ${bookId}`);
    } else {
      // If not logged in, navigate to the login page
      this.router.navigate(['/login']);
    }
  }
  viewBook(bookId: number): void {
    
    this.router.navigate(['/book', bookId]);
   
    
  }

  onSearchChange(event: Event): void {
    const value = (event.target as HTMLInputElement)?.value;
    this.searchTerm = value?.toLowerCase();
    if(this.searchTerm){ // Convert to lowercase for case-insensitive search
    this.displayedBooks = this.books.filter(book =>
      book.name.toLowerCase().includes(this.searchTerm) ||
      book.author.toLowerCase().includes(this.searchTerm)
    );
    }
    else{
      this.displayedBooks=[];
    }
  }
  // You can add other methods as needed

}

