import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationModalComponent } from 'src/app/shared/component/notification-modal/notification-modal.component';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { AppUser } from 'src/app/models/app-user.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  Form: FormGroup;
  privilegedUser: boolean;
  discount: number;

  constructor(
    private router: Router,
    private spinner: NgxSpinnerService,
    private notification: NotificationModalComponent,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.spinner.show();
    this.createForm();
    const user = JSON.parse(localStorage.getItem('store-app-user')) as AppUser;
    this.privilegedUser= user.role == "Privileged" ? true: false;
    this.discount= user.discount;
    this.Form.get('TotalPriceCtrl').disable();
    this.Form.get('DiscountCtrl').disable();
    this.Form.get('DiscountCtrl').setValue(this.discount);
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
  onSubmit() {
    this.spinner.show();

    const price = this.Form.get('PriceCtrl').value;
    const weight= this.Form.get('WeightCtrl').value;
    const totalPrice= (price*weight);
    const finalPrice= totalPrice - (totalPrice* this.discount)/100;
    this.Form.get('TotalPriceCtrl').setValue(finalPrice);
    this.spinner.hide();
   
  }
  reset(){
    this.Form.reset();
    this.Form.get('DiscountCtrl').setValue(this.discount);
  }
}
