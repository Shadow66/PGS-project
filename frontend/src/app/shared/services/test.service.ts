import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable()
export class TestService {
  constructor(private _http: HttpClient, private authService: AuthService) {}
  getTest() {
    return this._http.get('values');
  }

  postTest(message: string) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this._http.post('values', message, {
      headers: headers
    });
  }

  authTest() {
    return this._http.get('Authorize');
  }
}
