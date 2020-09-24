import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Phone } from '../models/phone';
import { HttpServiceClient } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class PhoneService {

  constructor(private http: HttpServiceClient) { }

  setCreatePhone(objPhone: Phone): Observable<number> {
    return this.http.Post(environment.apiUrl + `api/phone/setCreatePhone`,  objPhone);
  }

}
