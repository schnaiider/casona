import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Edge } from '../models/edge';
import { HttpServiceClient } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class EdgeService {

  constructor(private http: HttpServiceClient) { }

  getEdge(): Observable<Edge[]> {
    return this.http.Get(environment.apiUrl + `api/edge/getEdge`);
  }
}
