import { Injectable } from '@angular/core';
import { tap } from 'rxjs/operators';
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { NotificationModalComponent } from '../component/notification-modal/notification-modal.component';


@Injectable()
export class AppInterceptor implements HttpInterceptor {
    constructor(private router: Router, private notificationComp: NotificationModalComponent) { }
    // intercept function which will be intercepted/called for all http calls
    intercept(
        request: HttpRequest<any>,
        next: HttpHandler
    ): Observable<HttpEvent<any>> {

        // Creating headers to overload the request
        let updatedRequest: any;
        const user= localStorage.getItem('store-app-user');

        if (user) {
            const jwt = JSON.parse(user).token;
                    const authHeader = `Bearer ${jwt}`;
                    updatedRequest=  request.clone({
                        setHeaders: {
                            Authorization: authHeader,
                        } });
        }
        else {
            updatedRequest = request.clone();
        }
            return next.handle(updatedRequest)
                // Below commented code is to intercept response.
                .pipe(
                    tap(
                        event => {
                        },
                        error => {
                            // If user is not authenticated
                            if (error.status === 401) {
                                // // Setting error messagage.
                                this.notificationComp.showError('Unauthorized action: Please check username or password');
                            }
                            if (error.status === 403) {
                                 this.notificationComp.showError('Access Forbidden: Please contact admin');
                            }
                        }
                    )
                );
    }
}
