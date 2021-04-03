import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication/authentication.service';
import { AppUser } from 'src/app/models/app-user.model';
import { AuthGuardService } from 'src/app/shared/authguard/auth-guard.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  public form: FormGroup;
  private formSubmitAttempt: boolean;
  private isAuthenticated: boolean;

  constructor(
    private fb: FormBuilder,
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
    this.form = this.fb.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  isFieldInvalid(field: string) {
    return (
      (!this.form.get(field).valid && this.form.get(field).touched) ||
      (this.form.get(field).untouched && this.formSubmitAttempt)
    );
  }

  onSubmit() {
    if (this.form.valid) {
      const appUser = new AppUser();
      appUser.loginName = this.form.get('userName').value;
      appUser.password = this.form.get('password').value;
      this.authGuardService.login(appUser);
    }
    this.formSubmitAttempt = true;
  }
}
