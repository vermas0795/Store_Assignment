import { Injectable } from '@angular/core';
import { 
  ActivatedRouteSnapshot, 
  CanActivate, 
  Router, 
  RouterStateSnapshot } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication/authentication.service';


@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    private authService: AuthenticationService,
    private router: Router
  ) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):  boolean  {
    const user= this.authService.isAuthenticated();
    if(user)
    {
      return true;
    }
    this.router.navigate(['/login']);
  }
}