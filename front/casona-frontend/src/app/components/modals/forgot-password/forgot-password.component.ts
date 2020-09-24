import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {

  constructor(
    private _activeModal: NgbActiveModal
  ) { }

  ngOnInit(): void {
  }

  close() {
    this._activeModal.close(ForgotPasswordComponent)
  }

}
