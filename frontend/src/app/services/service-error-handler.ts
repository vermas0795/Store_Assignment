import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { NgxSpinnerService } from 'ngx-spinner';
import { NotificationModalComponent } from '../shared/component/notification-modal/notification-modal.component';
export type HandleError = <T> (operation?: string) => (error: HttpErrorResponse) => Observable<T>;
/** Handles HttpClient errors */
@Injectable()
export class HttpErrorHandler {
  constructor(private spinner: NgxSpinnerService, private notificationComp: NotificationModalComponent) {
  }
  /** Create handleError function that already knows the service name */
  createHandleError = (serviceName = '') => <T>
    (operation = 'operation') => this.handleError(serviceName, operation)
  /**
   * @param serviceName: name of the data service
   * @param operation: name of the failed operation
   * @param result: optional value to return as the observable result
   */
  handleError<T>(serviceName = '', operation = 'operation') {
    return (error: HttpErrorResponse): Observable<T> => {
      this.spinner.hide();
      // Handling custom errors from api.
      if (error.error && typeof (error.error) === 'string') {
        if (error.status === 417) {
          this.notificationComp.showWarning(error.error);
        } else {
          this.notificationComp.showError(error.error);
        }
        return;
      }  
      else if (error.status === 404) {
        // This is to handle No data Found exceptions while trying to download any file
        this.notificationComp.showError('Data not found, please contact admin.');
        return;
      } else if (error.status === 403) {
        this.notificationComp.showError('Forbidden action: Please contact admin');
        return;
      }
      this.notificationComp.showError('An error orrcured. Please try again later or contact admin.');
      if (error.error instanceof ErrorEvent) {
        // A client-side or network error occurred. Handle it accordingly.
        console.error('An error occurred:', error.error.message);
      } else {
        // the backend returned an unsuccessful response code
        console.error('Backend returned code ${error.status}, ' + 'body was: ${error.error}');
      }
      // return an observable with a user-facing error message
      return throwError('Something bad happened; please try again later.');
    };
  }
}
