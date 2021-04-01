import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class EnvService {
  // The values that are defined here are the default values that can
  // be overridden by appsettings.js
  // API url
  public apiUrl: '';
  constructor() {
  }
}
