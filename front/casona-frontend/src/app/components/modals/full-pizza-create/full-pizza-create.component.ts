import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-full-pizza-create',
  templateUrl: './full-pizza-create.component.html',
  styleUrls: ['./full-pizza-create.component.scss']
})
export class FullPizzaCreateComponent implements OnInit {

  constructor(
    private _activeModal: NgbActiveModal
  ) { }

  ngOnInit(): void {
  }

  close() {
    this._activeModal.close(FullPizzaCreateComponent)
  }
}