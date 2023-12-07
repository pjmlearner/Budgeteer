import { Component } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { UserCreateDialogComponent } from './user-create-dialog.component';

@Component({
  selector: 'app-user-management-user-detail',
  templateUrl: './user-detail.component.html',
})
export class UserDetailComponent {

  constructor(public dialog: MatDialog) {
  }

  openDialogO(): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.backdropClass = "hello";
    dialogConfig.disableClose = true; 

    const dialogRef = this.dialog.open(UserCreateDialogComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });

    //this.dialog.closeAll();//closeDialog();
  }

  closeDialog(): void {
    this.dialog.closeAll();
  }
}
