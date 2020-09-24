import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Item } from '../models/item';
import { HttpServiceClient } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(private http: HttpServiceClient) { }

  getProduct(idProductType: number): Observable<Item[]> {
  
    return this.http.Get(environment.apiUrl + `api/product/getProduct/${idProductType}`);
  }

}
