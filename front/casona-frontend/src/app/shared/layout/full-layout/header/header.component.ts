import { Component, OnInit } from '@angular/core';
import { NgbModalOptions, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from 'src/app/components/modals/login/login.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  isNavbarCollapsed=true;

  modalOption: NgbModalOptions = {
    backdrop: 'static',
    keyboard: false,
    windowClass: 'login-modal',
    centered: true
  }

  constructor(
    private _modalService: NgbModal
  ) { }

  ngOnInit(): void {
    
  }

  openLogin(): void {
    const modalref = this._modalService.open(LoginComponent, this.modalOption);
  }

}
