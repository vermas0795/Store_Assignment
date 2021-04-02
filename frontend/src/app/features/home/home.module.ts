import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { MaterialModule } from '../../material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxSpinnerModule } from 'ngx-spinner';
import { PrintDetailComponent } from './print-detail/print-detail.component';
import { HomeService } from 'src/app/services/home/home.service';

@NgModule({
  declarations: [HomeComponent, PrintDetailComponent],
  imports: [
    CommonModule,
    HomeRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    NgxSpinnerModule,
  ],
  exports:[],
  providers: [HomeService],
  entryComponents:[PrintDetailComponent]
})
export class HomeModule {}
