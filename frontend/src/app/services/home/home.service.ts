import { Injectable } from '@angular/core';
import { ServiceEndpoint } from '../service-endpoint';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../service-error-handler';
import { EstimationLogs } from 'src/app/models/estimation-logs.model';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/internal/operators/catchError';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  private handleError: any;
  Service_URL: ServiceEndpoint;

  constructor(private http: HttpClient, 
    private Url: ServiceEndpoint,
    serviceErrorHandler: HttpErrorHandler) { 
      this.Service_URL = Url;
      this.handleError = serviceErrorHandler.createHandleError('HomeService');
   }

   EstimationLogs(estimation): Observable<EstimationLogs>{
    return this.http.post<EstimationLogs>(this.Url.PostEstimationLogs_URL, estimation)
    .pipe(catchError(this.handleError('EstimationLogs')));
   }

}
