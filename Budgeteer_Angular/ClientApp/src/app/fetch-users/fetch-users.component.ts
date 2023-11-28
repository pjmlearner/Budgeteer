import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-users',
  templateUrl: './fetch-users.component.html'
})
export class FetchUsersComponent {
  public users: User[];
  public newUser: User;
  private url: string;
  private http: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.url = baseUrl;
    this.getUsers();
  }

  public addUser() {
    const newUser: User = {
      userId: 2,
      emailAddress: 'test_Email',
      firstName: 'John',
      lastName: 'Doe'
    }
    // Make an HTTP POST request to the API endpoint
    const endpoint = this.url + 'user'; // this.url + 'user/AddUserAsync';

    this.http.post<User>(endpoint, newUser).subscribe(
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

  public getUsers() {
    this.http.get<User[]>(this.url + 'user').subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }
}

interface User {
  userId: number;
  emailAddress: string;
  firstName: string;
  lastName: string;
}
