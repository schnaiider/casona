import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { OrderDetailTO, OrderItemTO, OrderTO } from '../models/order';
import { HttpServiceClient } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpServiceClient) { }

  setCreateOrder(ordr: OrderTO): Observable<number> {
    return this.http.Post(environment.apiUrl + `api/order/setCreateOrder`,  ordr);
  }

  setCreateOrderDetail(objOrderDetail: OrderDetailTO): Observable<number> {
    return this.http.Post(environment.apiUrl + `api/order/setCreateOrderDetail`,  objOrderDetail);
  }
  setCreateOrderItem(ordr: OrderItemTO): Observable<number> {
    return this.http.Post(environment.apiUrl + `api/order/setCreateOrderItem`,  ordr);
  }


  
}
