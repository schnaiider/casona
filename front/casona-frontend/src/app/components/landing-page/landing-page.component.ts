import { Component, OnInit } from '@angular/core';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { FullPizzaCreateComponent } from '../modals/full-pizza-create/full-pizza-create.component';
import { Order, OrderDetailTO, OrderHistoryTO, OrderItemTO } from 'src/app/core/models/order';
import { Item } from 'src/app/core/models/item';
import { StorageService } from 'src/app/core/service/storage.service';
import { OrderService } from 'src/app/core/service/order.service';
import { ItemService } from 'src/app/core/service/item.service';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.scss']
})
export class LandingPageComponent implements OnInit {

  modalOption: NgbModalOptions = {
    backdrop: 'static',
    keyboard: false,
    windowClass: 'login-modal',
    size: 'xl',
    centered: true
  }

  pizzas: Item[] = [];
  bebidas: Item[] = [];

  closeResult: string;

  order: Order = new Order(0, 0, 0);
  orderDetail: OrderDetailTO[] = [];
  orderItem: OrderItemTO[] = [];
  orderHistory: OrderHistoryTO;

  totalPrice: number = 0;


  constructor(private itemService: ItemService,
    private orderService: OrderService,
    private _modalService: NgbModal,
    private storageService: StorageService) { }

  ngOnInit(): void {
    this.getPizza();
    this.getBebidas();
  }
  
  getPizza() {
    this.itemService.getProduct(1).subscribe(result => {
      this.pizzas = [];
      this.pizzas = result;
    });
  }
  getBebidas() {
    this.itemService.getProduct(5).subscribe(result => {
      this.bebidas = [];
      this.bebidas = result;
    });
  }
  getItem(item: Item) {
    let existProduct: boolean = false;
    let orderDetail = {} as OrderDetailTO;
    let orderItem = {} as OrderItemTO;
    item.IdOrder = 0;
    this.orderDetail.forEach(element => {

      element.OrderItem.forEach(items => {
        if (items.IdProduct === item.IdProduct) {
          existProduct = true;
          item.IdOrder = this.orderDetail.find(x => x.IdOrder === element.IdOrder).IdOrder;
        }
      });
    });

    if (!existProduct) {
      orderDetail.IdOrder = 1 + Math.floor((1000 - 1) * Math.random());
      orderDetail.IdStatus = 1;
      orderDetail.Delivery = ''; // salir del cache de tipo de entrega
      orderDetail.IdOrderDetail = 0;
      orderDetail.IdEdge = 1; // cache
      orderDetail.Edge = 'sem borda'; // cache
      orderDetail.IdComposition = 1; // cache
      orderDetail.Composition = 'um sabor'; // cache
      orderDetail.IdCheese = 1; // cache
      orderDetail.Cheese = 'muzzarela'; // cache
      orderDetail.Quantity = 1;
      orderDetail.Price = item.Price;
      orderDetail.Commentary = item.Description;
      orderDetail.IdProductType = item.IdProductType;
      orderDetail.OrderItem = [];

      orderItem.IdOrderDetail = 0;
      orderItem.IdOrderItem = 0;
      orderItem.IdProduct = item.IdProduct;
      orderItem.ProductName = item.ProductName;
      orderDetail.OrderItem.push(orderItem);

      this.orderDetail.push(orderDetail);
      this.totalPrice = 0;
      for (let item of this.orderDetail) {
        this.totalPrice = this.totalPrice + (item.Price * item.Quantity);
      }
    }
    else {
      this.plusProduct(this.orderDetail.find(x => x.IdOrder === item.IdOrder));
    }
  }

  plusProduct(item: OrderDetailTO) {
    let orderDetail = {} as OrderDetailTO;
    orderDetail = this.orderDetail.find(x => x.IdOrder === item.IdOrder);
    orderDetail.Quantity = orderDetail.Quantity + 1;
    this.totalPrice = this.totalPrice + orderDetail.Price;
  }
  minusProduct(item: OrderDetailTO) {
    let orderDetail = {} as OrderDetailTO;
    orderDetail = this.orderDetail.find(x => x.IdOrder === item.IdOrder);
    orderDetail.Quantity = orderDetail.Quantity - 1;
    if (orderDetail.Quantity <= 0) {
      this.orderDetail.pop().IdOrder = orderDetail.IdOrder;
      this.totalPrice = this.totalPrice - orderDetail.Price;
    } else {
      this.totalPrice = this.totalPrice - orderDetail.Price;
    }

  }
  endOrder() {

    // validar que exista direccion en cache.
    if (this.storageService.getAddressInfo().length > 0) {
      // insert order
      this.order.IdDelivery = 1; // viene de cache
      this.order.IdOrder = 0;
      this.order.IdUser = 1; // viene de cache
     
      this.orderService.setCreateOrder(this.order).subscribe(result => {
        this.orderDetail.forEach(element => {
          element.IdOrder = result;
          this.orderService.setCreateOrderDetail(element).subscribe(res => {
            element.OrderItem.forEach(item => {
              item.IdOrderDetail = res;
              this.orderService.setCreateOrderItem(item).subscribe(rest => {
                this.orderDetail = [];
                this.totalPrice = 0;
              });
            });
          });
        });
      });
    }
    else{
     // abrir direccio 
    }
  }

  openCreatePizzaModal(item: Item) {
    const modalRef =  this._modalService.open(FullPizzaCreateComponent, this.modalOption);
    modalRef.componentInstance.objProduct = item;
    modalRef.componentInstance.passEntry.subscribe((receivedEntry) => {
      
    });
  }

}
