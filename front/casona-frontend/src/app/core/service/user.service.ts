import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { HttpServiceClient } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpServiceClient) { }

  setCreateUser(usr: User): Observable<number> {
    return this.http.Post(environment.apiUrl + `api/user/setCreateUser`,  usr);
  }
  getListUser(email: string, password: string): Observable<User[]> {
    return this.http.Get(environment.apiUrl + `api/user/getListUser/${email}/${password}`);    
  }

  getListUserInfo(idUser: number): Observable<User[]> {
    return this.http.Get(environment.apiUrl + `api/user/getListUserInfo/${idUser}`);
  }

}
