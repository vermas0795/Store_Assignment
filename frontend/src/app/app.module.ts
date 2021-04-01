import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppInterceptor } from './shared/interceptor/app-interceptor';
import { HttpErrorHandler } from './services/service-error-handler';
import { NotificationModalComponent } from './shared/component/notification-modal/notification-modal.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { MaterialModule } from './material.module';
import { NavigationComponent } from './features/navigation/navigation.component';

@NgModule({
  declarations: [
    AppComponent,
    NotificationModalComponent,
    NavigationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MaterialModule,
    ToastrModule.forRoot({
      timeOut: 5500,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true
    }),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AppInterceptor,
      multi: true
    },
     HttpErrorHandler,NotificationModalComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
