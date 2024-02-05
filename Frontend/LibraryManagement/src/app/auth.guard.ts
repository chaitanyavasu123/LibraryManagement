// auth.guard.ts

import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    // Check if the user is authenticated (you need to replace this with your authentication logic)
    const mytoken :any =localStorage.getItem('token');
    

    if (mytoken) {
      return true; // Allow access to the route
    } else {
      // Navigate to the login page
      console.log("You haveto login first")
      this.router.navigate(['/login']);
      return false;
    }
  }
}

