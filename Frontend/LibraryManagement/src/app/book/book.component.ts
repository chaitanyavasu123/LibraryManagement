import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookService } from '../Services/book.service';
import {Book} from '../models/book.model';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {
  bookId!: number;
  book!: Book; // Replace 'any' with your actual book model
  userId: number =1;
  isloggedIn=false;

  constructor(private route: ActivatedRoute, private bookService: BookService,private router: Router) { }

  ngOnInit(): void {
   
    this.route.params.subscribe(params => {
      this.bookId = +params['id']; // '+' is used to convert string to number
      this.getBookDetails();
    });
  }

  getBookDetails() {
    this.bookService.getBookById(this.bookId).subscribe(
      (data: Book) => {
        this.book = data; // Replace 'any' with your actual book model
      },
      error => {
        console.error('Error retrieving book details:', error);
      }
    );
  }
  comeback() {
    // Implement logout functionality here
    // You might want to clear the stored token and navigate to the login page
    
    this.router.navigate(['/dashboard']);
  } 
  comehome(){
    this.router.navigate(['/']);
  }
  logout() {
    // Implement logout functionality here
    // You might want to clear the stored token and navigate to the login page
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
    }
    isLoggedIn(): boolean {
      // Implement your logic to check if the user is logged in
      const mytoken :any =localStorage.getItem('token');
      if(mytoken) return true;
      return false; // Replace with your actual authentication check
    }
  
    borrowBook(bookId: number): void {
      const mytoken :any =localStorage.getItem('token');
      if(mytoken){
      const helper = new JwtHelperService();

      const decodedToken = helper.decodeToken(mytoken);
      this.userId = decodedToken.unique_name;
     
      // Call the borrow functionality in your BookService
      this.bookService.getBookById(bookId).subscribe((book) => {
        const ownerId = book.ownerId; 
     
      this.bookService.borrowBook(bookId, ownerId,this.userId)
        .subscribe(response => {
          // Handle the response if needed
          alert('Book successfully borrowed!');
          console.log('Book borrowed successfully:', response);
          // Refresh the available books list
          this.router.navigate(['/dashboard']);
        },
        error => {
          // Handle error, which will contain the exception message
          alert('there is problem!');
          console.error(error);
          // Show an appropriate message to the user
        });
      });
      }
      else{
        this.router.navigate(['/login']);
      }
    }
}

