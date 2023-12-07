// user.service.ts
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { User } from './user.model';

@Injectable({
  providedIn: 'root',
})
export class UserManagementService {

  private url: string;
  private http: HttpClient;
  private users: User[];
  private newUser: User;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.url = baseUrl;
    this.getUsers();
  }

  
  getUsers() : User[] {
    this.http.get<User[]>(this.url + 'user').subscribe(result => {
      this.users = result;
    }, error => console.error(error));
    return this.users;
  }

  addUser(user: User) {
    // Make an HTTP POST request to the API endpoint
    const endpoint = this.url + 'user'; // this.url + 'user/AddUserAsync';

    this.http.post<User>(endpoint, user).subscribe(
      result => {
        // Handle success, e.g., update UI or take further action
        console.log('User added successfully:', result);
        this.getUsers();
      },
      error => {
        // Handle error, e.g., display an error message
        console.error('Error adding user:', error);
      });
  }
}


//// user-list.component.ts
//import { Component, OnInit } from '@angular/core';
//import { UserService } from './user.service';

//@Component({
//  selector: 'app-user-list',
//  // ...
//})
//export class UserListComponent implements OnInit {
//  constructor(private userService: UserService) { }

//  ngOnInit() {
//    this.userService.getUsers();
//  }
//}

//// add-user.component.ts
//import { Component } from '@angular/core';
//import { UserService } from './user.service';

//@Component({
//  selector: 'app-add-user',
//  // ...
//})
//export class AddUserComponent {
//  constructor(private userService: UserService) { }

//  addUser() {
//    this.userService.addUser(/* user data */);
//  }
//}
