import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Edge } from 'src/app/core/models/edge';
import { Item, ItemTO } from 'src/app/core/models/item';
import { EdgeService } from 'src/app/core/service/edge.service';

@Component({
  selector: 'app-full-pizza-create',
  templateUrl: './full-pizza-create.component.html',
  styleUrls: ['./full-pizza-create.component.scss']
})
export class FullPizzaCreateComponent implements OnInit {

  @Input() objProduct: Item;
  @Output() passEntry: EventEmitter<any> = new EventEmitter();

  isEdge: boolean = false;

  edge: Edge[] = [];

  constructor(
    private _activeModal: NgbActiveModal,
    private edgeService: EdgeService
  ) { }

  ngOnInit(): void {
    this.getEdge();
  }

  close() {
    this._activeModal.close(FullPizzaCreateComponent)
  }

  passBack() {
    this.passEntry.emit(this.objProduct);
  }

  edgeItem(_edge: Edge) {    
    console.log(_edge); // enviar a cache
  }


  getEdge() {
    this.edgeService.getEdge().subscribe(result => {
      this.edge = [];
      this.edge = result;
    });
  }

}