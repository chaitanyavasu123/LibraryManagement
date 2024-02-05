import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../Services/user.service';
import { BookService } from '../Services/book.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  tokensAvailable: number = 0;
  availableBooks: any[] = [];
  userId: number =1;

  constructor(private userService: UserService, private bookService:BookService, private router: Router) { }

  ngOnInit(): void {
        const mytoken :any =localStorage.getItem('token');
        const helper = new JwtHelperService();

        const decodedToken = helper.decodeToken(mytoken);
        this.userId = decodedToken.unique_name;
    // Fetch tokens available when the component is initialized
    this.fetchTokensAvailable();
    this.getAvailableBooks();
  }
  getAvailableBooks(): void {
    // const mytoken :any =localStorage.getItem('token');
    //     const helper = new JwtHelperService();

    //     const decodedToken = helper.decodeToken(mytoken);
    //     this.userId = decodedToken.unique_name;
    this.bookService.getAvailableBooksUser(this.userId)
      .subscribe(books => this.availableBooks = books);
  }

  fetchTokensAvailable() {
    // Assuming you have a method in UserService to get tokens
        // const mytoken :any =localStorage.getItem('token');
        // const helper = new JwtHelperService();

        // const decodedToken = helper.decodeToken(mytoken);
        // console.log(decodedToken);
        // const userId = decodedToken.unique_name;
        // console.log(userId);
    this.userService.getUserTokens(this.userId).subscribe(
      tokens => {
        this.tokensAvailable = tokens;
      },
      error => {
        console.error('Error fetching tokens:', error);
      }
    );
  }

  logout() {
    // Implement logout functionality here
    // You might want to clear the stored token and navigate to the login page
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  goToProfile() {
    // Navigate to the profile page
    this.router.navigate(['/profile']);
  }
  viewBookDetails(bookId: number): void {
    this.router.navigate(['/book', bookId]);
  }
  borrowBook(bookId: number): void {

    // Call the borrow functionality in your BookService
    this.bookService.getBookById(bookId).subscribe((book) => {
      const ownerId = book.ownerId; 
   
    this.bookService.borrowBook(bookId, ownerId,this.userId)
      .subscribe(response => {
        // Handle the response if needed
        alert('Book successfully borrowed!');
        console.log('Book borrowed successfully:', response);
        // Refresh the available books list
        this.getAvailableBooks();
      },
      error => {
        // Handle error, which will contain the exception message
        alert('there is problem!');
        console.error(error);
        // Show an appropriate message to the user
      });
    });
  }
}
