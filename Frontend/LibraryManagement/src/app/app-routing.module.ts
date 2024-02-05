// app-routing.module.ts

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { BookComponent } from './book/book.component';
import { ProfileComponent } from './profile/profile.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AddBookComponent } from './addbook/addbook.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
    // Default route redirects to HomeComponent
  { component: LoginComponent,  path: 'login' },
  { component: BookComponent, path: 'book/:id' },
  {component:ProfileComponent,path:'profile',canActivate: [AuthGuard]},
  { component: DashboardComponent, path: 'dashboard',canActivate: [AuthGuard]},
  { component: AddBookComponent,path: 'addbook',canActivate: [AuthGuard] },
  { component: HomeComponent, path:'' },
  // Add other routes as needed
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
