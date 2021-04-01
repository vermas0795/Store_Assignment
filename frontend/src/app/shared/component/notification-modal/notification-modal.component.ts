import { Component, OnInit } from '@angular/core';
import { ToastrService, IndividualConfig } from 'ngx-toastr';

@Component({
  selector: 'app-notification-modal',
  templateUrl: './notification-modal.component.html',
  styleUrls: ['./notification-modal.component.css']
})
export class NotificationModalComponent implements OnInit {

  constructor(private toastrService: ToastrService) {
    this.toastrService = toastrService;
  }
  ngOnInit() {
  }

  showSuccess = (message) => {
    this.toastrService.success(message);
  }

  showError = (message) => {
    this.toastrService.error(message);
  }

  showWarning = (message) => {
    this.toastrService.warning(message, '', {
      closeButton: true
    });
  }

  // Error notification with close option. Will be closed only when user clicks close button.
  showStaticError = (message) => {
    this.toastrService.error(message, '', {
      // disableTimeOut: true,
      timeOut: 10000,
      closeButton: true
    });
  }

  // Warning message with custome delay
  showDelayWarning = (message, timeOut) => {
    this.toastrService.warning(message, '', { timeOut: timeOut });
  }

  showDelaySuccess = (message, timeOut) => {
    this.toastrService.success(message, '', { timeOut: timeOut });
  }

  showStaticWarning = (message, timeOut) => {
    this.toastrService.warning(message, '', {
      // disableTimeOut: true,
      timeOut: timeOut,
      closeButton: true
    });
  }

  info(message?: string, title?: string, override?: Partial<IndividualConfig>) {
    this.toastrService.info(message, title, override);
  }

  clear(toastId?: number) {
    this.toastrService.clear(toastId);
  }
}
