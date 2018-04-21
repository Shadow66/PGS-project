import { Injectable } from '@angular/core';
import { EventListModel } from '../models/event.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class ApiService {
  constructor(private _http: HttpClient) {}
  public url = 'http://localhost:54377/api/';

  getTest() {
    return this._http.get(this.url + 'values');
  }

  postTest(message: string) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this._http.post(this.url + 'values', message, { headers: headers });
  }


}
