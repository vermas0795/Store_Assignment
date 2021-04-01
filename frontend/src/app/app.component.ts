import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { AuthenticationService } from './services/authentication/authentication.service';
import { Router } from '@angular/router';
import { AuthGuardService } from './shared/authguard/auth-guard.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Store-App';
  isAuthenticated:boolean;
  
  constructor(
    private router: Router,
    private authGuardService: AuthGuardService
  ) {}
  
  ngOnInit() {
    this.authGuardService.IsLoggedIn.subscribe((data) => {
      this.isAuthenticated = data;
      if (this.isAuthenticated) {
        this.router.navigate(['/home']);
      }
    });
  }
}
