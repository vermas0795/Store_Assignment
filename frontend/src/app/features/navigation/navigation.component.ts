import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationModalComponent } from 'src/app/shared/component/notification-modal/notification-modal.component';
import { AuthGuardService } from 'src/app/shared/authguard/auth-guard.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css'],
})
export class NavigationComponent implements OnInit {
  //variable declaration
  isCollapsed = true;
  loggedInUser: string;
  roleType: string;
  copyRightYear: number = new Date().getFullYear();
  isAuthenticated: boolean;

  constructor(
    private notification: NotificationModalComponent,
    private router: Router,
    private authGuardService: AuthGuardService
  ) {}

  ngOnInit() {
    this.authGuardService.IsLoggedIn.subscribe((data) => {
      this.isAuthenticated = data;
      if (this.isAuthenticated) {
        const user = JSON.parse(localStorage.getItem('store-app-user'));
        this.loggedInUser = user.userName;
        this.roleType = user.role;
      }
    });
  }

  // Function used to logout from the application
  logout() {
    if (confirm('Are you sure you want to logout?')) {
      localStorage.clear();
      this.authGuardService.updatelogin(false);
      this.notification.showSuccess('Logged out successfully!');
      this.router.navigate(['/login']);
    }
  }
}
