import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-users',
  templateUrl: './fetch-users.component.html'
})
export class FetchUsersComponent {
  public users: User[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<User[]>(baseUrl + 'user').subscribe(result => {
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
