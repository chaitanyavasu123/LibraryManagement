// Import necessary modules and services
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BookService } from '../Services/book.service';
import {Book} from '../models/book.model'; // Update the path
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-addbook',
  templateUrl: './addbook.component.html',
  styleUrls: ['./addbook.component.css']
})
export class AddBookComponent implements OnInit {
  addBookForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private bookService: BookService
  ) {}

  ngOnInit(): void {
    // Initialize the form with default values
    this.addBookForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      rating: [0, [Validators.required, Validators.min(0), Validators.max(5)]],
      author: ['', [Validators.required]],
      genre: ['', [Validators.required]],
      description: ['', [Validators.required]]
    });
  }

  // Function to handle form submission
  onSubmit() {
    // Check if the form is valid
    if (this.addBookForm.valid) {
      // Get the user ID from your authentication service or JWT token
       // Replace with your actual logic to get the user ID
      const mytoken :any =localStorage.getItem('token');
        const helper = new JwtHelperService();

        const decodedToken = helper.decodeToken(mytoken);
        const userId = decodedToken.unique_name;
      // Create a new book object
      const newBook: Book = {
        name: this.addBookForm.value.name,
        rating: this.addBookForm.value.rating,
        author: this.addBookForm.value.author,
        genre: this.addBookForm.value.genre,
        isBookAvailable: true,
        description: this.addBookForm.value.description,
        ownerId: userId,
        currentlyBorrowedById: null
      };

      // Call the service to add the book
      this.bookService.addBook(newBook).subscribe(
        response => {
          alert('Book successfully added!');
          console.log('Book added successfully:', response);
          // Redirect to the dashboard or book list page
          this.router.navigate(['/dashboard']);
        },
        error => {
          console.error('Error adding book:', error);
        }
      );
    }
  }
  comeback() {
    // Implement logout functionality here
    // You might want to clear the stored token and navigate to the login page
    
    this.router.navigate(['/profile']);
  } 
  get name() {
    return this.addBookForm.get('name');
  }
  
  get rating() {
    return this.addBookForm.get('rating');
  }
  
  get author() {
    return this.addBookForm.get('author');
  }
  
  get genre() {
    return this.addBookForm.get('genre');
  }
  
  get description() {
    return this.addBookForm.get('description');
  }
}
