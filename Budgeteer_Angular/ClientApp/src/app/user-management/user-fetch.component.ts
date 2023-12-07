import { Component, Inject } from '@angular/core';
import { UserManagementService } from './user-management.service';
import { User } from './user.model';

@Component({
  selector: 'app-user-management-user-fetch',
  templateUrl: './user-fetch.component.html'
})
export class UserFetchComponent {
  private users: User[];

  constructor(private userManagementService: UserManagementService) {
    this.getUsers();
  }

  public getUsers() {
    this.users = this.userManagementService.getUsers();
  }
}
