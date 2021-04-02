import { EnvService } from './env.service';
import { Injectable } from '@angular/core';

@Injectable()
export class ServiceEndpoint {
  API_URL;
 
  public GetUserInfo_URL;
  public PostEstimationLogs_URL;


  constructor(envi: EnvService) {
    this.API_URL = envi.apiUrl;
    this.GetUserInfo_URL= this.API_URL+'authenticate';
    this.PostEstimationLogs_URL= this.API_URL+'estimationLogs';
    
  }
}