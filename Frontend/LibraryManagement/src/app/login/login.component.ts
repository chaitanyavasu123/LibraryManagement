// login.component.ts

import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../Services/user.service';
import { FormsModule } from '@angular/forms';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Token } from '@angular/compiler';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username = '';
  password = '';
  errorMessage = '';

  constructor(private userService: UserService, private router: Router) { }

  login(): void {
    this.userService.login(this.username, this.password).subscribe(
      response => {
        // Save the token or user information as needed
        localStorage.setItem('token', response.token);
        console.log(response);
        var mytoken=localStorage.getItem('token');
        const helper = new JwtHelperService();

        const decodedToken = helper.decodeToken(response.token);
        console.log(decodedToken);
        const userId = decodedToken.unique_name;
        console.log(userId);
        
        // Redirect to the home page or another desired page
        this.router.navigate(['/dashboard']);
      },
      error => {
        this.errorMessage = 'Invalid username or password';
      }
    );
  }
  comeback() {
    // Implement logout functionality here
    // You might want to clear the stored token and navigate to the login page
    
    this.router.navigate(['/']);
  } 
}

