import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpClient } from '@angular/common/http';
import { AuthenticationUserModel } from '../models/authenticatonUser.model';
import { Router } from '@angular/router';

@Injectable()
export class AuthService {
  constructor(
    private apiService: ApiService,
    private _http: HttpClient,
    private router: Router
  ) {}
  url = 'Authorize';
  token: string;

  signUpUser(email: string, password: string) {
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
    return this._http.post(this.apiService.url + this.url, user).subscribe(
      (token: string) => {
        this.router.navigate(['/']);
        this.token = token;
      },
      error => console.log(error)
    );
  }

  logout() {
    this.token = null;
    this.router.navigate(['/']);
  }

  isAuthenticated() {
    return this.token != null;
  }
}
