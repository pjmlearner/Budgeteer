// feature1.module.ts
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

// Import components, directives, and services related to Feature1
import { UserFetchComponent } from './user-fetch.component';
import { UserCreateComponent } from './user-create.component';
import { UserManagementService } from './user-management.service';
import { UserCreateDialogComponent } from './user-create-dialog.component';

@NgModule({
  declarations: [
    // List all components, directives, and pipes belonging to this module
    UserFetchComponent,
    UserCreateComponent,
    UserCreateDialogComponent
  ],
  imports: [
    // Import modules that this module depends on
    CommonModule,
    // Other modules...
  ],
  providers: [
    // List all services that this module provides
    UserManagementService,
  ],
  exports: [
    // Expose components, directives, and pipes for use in other modules
    UserFetchComponent,
    UserCreateComponent,
    UserCreateDialogComponent
  ],
})
export class UserManagementModule { }
