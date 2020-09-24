import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Address,  cepTO, Commune } from '../models/address';
import { HttpServiceClient } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  constructor(private http: HttpServiceClient) { }

  getCEP(uri: string): Observable<cepTO> {
    return this.http.Get(uri);
  }


  getCommune(): Observable<Commune[]> {
    return this.http.Get(environment.apiUrl + `api/address/getCommune`);
  }

  setCreateAddress(adrs: Address): Observable<number> {
    return this.http.Post(environment.apiUrl + `api/address/setCreateAddress`, adrs);
  }
}
