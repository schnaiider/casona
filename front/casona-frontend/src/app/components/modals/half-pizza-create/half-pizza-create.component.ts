import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-half-pizza-create',
  templateUrl: './half-pizza-create.component.html',
  styleUrls: ['./half-pizza-create.component.scss']
})
export class HalfPizzaCreateComponent implements OnInit {

  constructor(
    private _activeModal: NgbActiveModal
  ) { }

  ngOnInit(): void {
  }

  close() {
    this._activeModal.close(HalfPizzaCreateComponent)
  }
}
