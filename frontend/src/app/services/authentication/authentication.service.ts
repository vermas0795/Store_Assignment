import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ServiceEndpoint } from '../service-endpoint';
import { AppUser } from '../../models/app-user.model';
import { catchError } from 'rxjs/operators';
import { HttpErrorHandler } from '../service-error-handler';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private handleError: any;
  Service_URL: ServiceEndpoint;

  constructor(private http: HttpClient, 
    private Url: ServiceEndpoint,
    serviceErrorHandler: HttpErrorHandler) { 
      this.Service_URL = Url;
      this.handleError = serviceErrorHandler.createHandleError('AuthenticationService');
   }

  // Service call to get the details of logged in user
  login(user:AppUser) : Observable<AppUser>   {
    return this.http.post<AppUser>(this.Url.GetUserInfo_URL, user)
  }

  isAuthenticated(){
    const user= localStorage.getItem('store-app-user');
    if(user){
      return true;
    }
    return false;
  }
}
