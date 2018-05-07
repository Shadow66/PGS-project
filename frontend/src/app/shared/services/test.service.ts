import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable()
export class TestService {
  constructor(
    private apiService: ApiService,
    private _http: HttpClient,
    private authService: AuthService
  ) {}
  getTest() {
    return this._http.get(this.apiService.url + 'values');
  }

  postTest(message: string) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this._http.post(this.apiService.url + 'values', message, {
      headers: headers
    });
  }

  authTest() {
    const headers = new HttpHeaders({
      Authorization: 'Bearer ' + this.authService.token['token'],
      'Content-Type': 'application/json'
    });
    return this._http.get(this.apiService.url + 'Authorize', {
      headers: headers
    });
  }
}
