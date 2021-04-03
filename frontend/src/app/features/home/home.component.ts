import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationModalComponent } from 'src/app/shared/component/notification-modal/notification-modal.component';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { AppUser } from 'src/app/models/app-user.model';
import { HomeService } from 'src/app/services/home/home.service';
import { EstimationLogs } from 'src/app/models/estimation-logs.model';
import { MatDialog } from '@angular/material/dialog';
import { PrintDetailComponent } from './print-detail/print-detail.component';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  Form: FormGroup;
  user = new AppUser();
  estimation = new EstimationLogs();
  isCalculated = false;
  isPrivileged = false;

  constructor(
    private router: Router,
    private spinner: NgxSpinnerService,
    private notification: NotificationModalComponent,
    private formBuilder: FormBuilder,
    private homeService: HomeService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.spinner.show();
    this.createForm();
    this.user = JSON.parse(localStorage.getItem('store-app-user')) as AppUser;
    if (this.user) {
      this.isPrivileged = this.user.role == 'Privileged' ? true : false;
    }
    this.Form.get('DiscountCtrl').disable();
    this.Form.get('DiscountCtrl').setValue(this.user.discount);
    this.spinner.hide();
  }

  createForm() {
    this.Form = this.formBuilder.group({
      PriceCtrl: ['', Validators.required],
      WeightCtrl: ['', Validators.required],
      DiscountCtrl: [''],
    });
  }

  roundNumber(num, decimals) {
    var t = Math.pow(10, decimals);   
    return (Math.round((num * t) + (decimals>0?1:0)*(Math.sign(num) * (10 / Math.pow(100, decimals)))) / t).toFixed(decimals);
  }

  onSubmit() {
    this.spinner.show();
    const withoutDiscountPrice =
      this.Form.get('PriceCtrl').value * this.Form.get('WeightCtrl').value;
    const totalPrice =
      withoutDiscountPrice - (withoutDiscountPrice * this.user.discount) / 100;
    this.estimation.appUserId = this.user.id;
    this.estimation.discount = +this.user.discount;
    this.estimation.pricePerGram = +this.roundNumber(this.Form.get('PriceCtrl').value,4);
    this.estimation.weight = +this.roundNumber(this.Form.get('WeightCtrl').value,4);
    this.estimation.totalPrice = +this.roundNumber(totalPrice,8);
    this.homeService.EstimationLogs(this.estimation).subscribe((data) => {
      if (data.id > 0) {
        this.spinner.hide();
        this.isCalculated = true;
        if (this.isPrivileged) {
          this.notification.showSuccess('Privilged Discount added.');
        }
      }
    });
  }
  reset() {
    this.spinner.show();
    this.Form.reset();
    this.estimation.totalPrice = null;
    this.isCalculated = false;
    this.Form.get('DiscountCtrl').setValue(this.user.discount);
    this.spinner.hide();
  }
  printToScreen() {
    const dialogRef = this.dialog.open(PrintDetailComponent, {
      width: '900px',
      // height: '560px',
      // minHeight: 'calc(100vh - 80px)',
      height: 'auto',
      data: { Estimation: this.estimation, userType: this.user.role },
      autoFocus: false,
      position: { top: '7%' },
    });
    this.router.events.subscribe(() => {
      dialogRef.close();
    });
  }
  printToFile() {
    this.spinner.show();
    let DATA = document.getElementById('estimation');
    const d = new Date();
    let month = `${d.getMonth() + 1}`;
    let day = `${d.getDate()}`;
    const year = d.getFullYear();

    const hour = d.getHours();
    const min = d.getMinutes();
    const sec = d.getSeconds();

    html2canvas(DATA).then((canvas) => {
      let fileWidth = 208;
      let fileHeight = (canvas.height * fileWidth) / (canvas.width - 400);
      const FILEURI = canvas.toDataURL('image/png');
      let doc = new jsPDF('p', 'mm', 'a4');
      doc.setFontSize(20);
      doc.setTextColor(107);
      doc.text('Calculation Details', 20, 20);
      let position = 40;
      doc.addImage(FILEURI, 'PNG', 0, position, fileWidth, fileHeight);
      doc.save(
        `estimation_${`${[year, month, day].join('-')}@${[hour, min, sec].join(
          '_'
        )}`}.pdf`
      );
      this.spinner.hide();
    });
  }
  printToPaper() {
    this.notification.showWarning('This will be added soon. Stay tuned!');
  }
}
