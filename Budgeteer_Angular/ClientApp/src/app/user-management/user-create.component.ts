import { Component, Inject } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { UserCreateDialogComponent } from './user-create-dialog.component';

@Component({
  selector: 'app-user-management-user-create',
  templateUrl: './user-create.component.html'
})
export class UserCreateComponent {

  constructor(public dialog: MatDialog) {
  }

 openDialogO(): void {
    let dialogConfig = new MatDialogConfig();
   dialogConfig.hasBackdrop = false;
    

    this.dialog.open(UserCreateDialogComponent, dialogConfig);

    //dialogRef.afterClosed().subscribe(result => {
    //  console.log('The dialog was closed');
    //});
  }

  closeDialog(): void {
    this.dialog.closeAll();
  }

}


