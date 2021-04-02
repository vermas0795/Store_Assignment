import { Injectable } from '@angular/core';
import { AppUser } from '../../models/app-user.model';
import { BehaviorSubject } from 'rxjs';
import { AuthenticationService } from 'src/app/services/authentication/authentication.service';
import { Router } from '@angular/router';
import { NotificationModalComponent } from '../component/notification-modal/notification-modal.component';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService {
  private handleError: any;
  authenticationService;
  private loggedIn = new BehaviorSubject<boolean>(false); 
  constructor(private authService:AuthenticationService,private router: Router,
    private notification: NotificationModalComponent){
    let storedProp = localStorage.getItem('store-app-user');
    if (storedProp)
    this.loggedIn.next(true);
  }

  get IsLoggedIn() {
    return this.loggedIn.asObservable(); 
  }

   updatelogin(message:boolean){
    return this.loggedIn.next(message); 
   }


   login(appUser: AppUser) {
     this.authService.login(appUser).subscribe(data=>{
       if(data)
       {
        localStorage.setItem('store-app-user',JSON.stringify(data));
        this.loggedIn.next(true);
        this.notification.showSuccess("Login Successful!")
        this.router.navigate(['/home']);
       }
       else{
        this.notification.showError("Some error occurred!")
       }
     });
   }
}