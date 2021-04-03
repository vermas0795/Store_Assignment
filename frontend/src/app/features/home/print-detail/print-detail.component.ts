import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AppUser } from 'src/app/models/app-user.model';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { NotificationModalComponent } from 'src/app/shared/component/notification-modal/notification-modal.component';
import { HomeService } from 'src/app/services/home/home.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EstimationLogs } from 'src/app/models/estimation-logs.model';

@Component({
  selector: 'app-print-detail',
  templateUrl: './print-detail.component.html',
  styleUrls: ['./print-detail.component.css'],
})
export class PrintDetailComponent implements OnInit {
  Form: FormGroup;
  isPrivileged = false;

  constructor(
    private router: Router,
    private spinner: NgxSpinnerService,
    private notification: NotificationModalComponent,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<PrintDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public Data: any
  ) {}

  ngOnInit(): void {
    this.spinner.show();
    this.createForm();
    this.Form.get('TotalPriceCtrl').disable();
    this.Form.get('DiscountCtrl').disable();
    this.Form.get('DiscountCtrl').setValue(this.Data.Estimation.discount);
    this.Form.get('PriceCtrl').setValue(this.Data.Estimation.pricePerGram);
    this.Form.get('WeightCtrl').setValue(this.Data.Estimation.weight);
    this.isPrivileged = this.Data.userType == 'Privileged' ? true : false;
    this.spinner.hide();
  }

  createForm() {
    this.Form = this.formBuilder.group({
      PriceCtrl: ['', Validators.required],
      WeightCtrl: ['', Validators.required],
      DiscountCtrl: [''],
      TotalPriceCtrl: [''],
    });
  }
}
