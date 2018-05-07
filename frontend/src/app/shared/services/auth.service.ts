import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpClient } from '@angular/common/http';
import { AuthenticationUserModel } from '../models/authenticatonUser.model';

@Injectable()
export class AuthService {
  constructor(private apiService: ApiService, private _http: HttpClient) {}
  url = 'Authorize';
  token: string;

  signUpUser(email: string, password: string) {
    // const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const user: AuthenticationUserModel = new AuthenticationUserModel(
      email,
      password
    );
    return this._http.post(this.apiService.url + this.url + '/Register', user);
  }
  signInUser(email: string, password: string) {
    const user: AuthenticationUserModel = new AuthenticationUserModel(
      email,
      password
    );
    return this._http.post(this.apiService.url + this.url, user)
    .subscribe((token: string) => this.token = token, error => console.log(error));
  }

  logout() {
    // TODO: logout in back end
    this.token = null;
  }

  isAuthenticated() {
    return this.token != null;
  }
}
