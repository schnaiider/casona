import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { HttpServiceClient } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor(private http: HttpServiceClient) { }

  public saveUserProfile(profile: string): void {
    localStorage.setItem('user_profile', profile);
  }

  public getUserProfile(): number {
    try {
      if (localStorage.getItem('user_profile') !== 'undefined' &&
        localStorage.getItem('user_profile') !== null) {
        return JSON.parse(localStorage.getItem('user_profile')) as number;
      } else { return 0; }
    } catch (e) {
      return 0;
    }
  }

  public saveUserInfo(user: string): void {
    localStorage.setItem('user_info', user);
  }

  public getUserInfo(): User[] {
    try {
      if (localStorage.getItem('user_info') !== 'undefined' &&
        localStorage.getItem('user_info') !== null) {
        return JSON.parse(localStorage.getItem('user_info')) as User[];
      } else { return []; }
    } catch (e) {
      return [];
    }
  }


  public saveAddressInfo(user: string): void {
    localStorage.setItem('address_info', user);
  }

  public getAddressInfo(): User[] {
    try {
      if (localStorage.getItem('address_info') !== 'undefined' &&
        localStorage.getItem('address_info') !== null) {
        return JSON.parse(localStorage.getItem('address_info')) as User[];
      } else { return []; }
    } catch (e) {
      return [];
    }
  }





}
