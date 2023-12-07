import { Component, Inject } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { UserManagementService } from './user-management.service';
import { User } from './user.model';

@Component({
  selector: 'app-user-management-user-create-dialor',
  templateUrl: './user-create-dialog.component.html'
})
export class UserCreateDialogComponent {
  private newUser: User = new User();

  constructor(public dialogRef: MatDialogRef<UserCreateDialogComponent>,
    private userManagementService: UserManagementService) {
  }

  onOkClick(): void {
    this.userManagementService.addUser(this.newUser);
  }

  onCancelClick(): void {
    this.dialogRef.close();
  }

}
