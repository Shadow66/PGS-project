import { Injectable } from '@angular/core';
// import { Http, Headers, Response } from '@angular/http';
import 'rxjs/add/operator/map';
import { EventListModel } from './models/event.model';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import 'rxjs/add/operator/map';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class ApiService {
  constructor(private _http: HttpClient) {}
  url = 'http://localhost:54377/api/';

  getTest() {
    return this._http.get(this.url + 'values');
  }

  postTest(message: string) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this._http.post(this.url + 'values', message, { headers: headers });
  }
  getEvents(searchInput: string): Observable<EventListModel[]> {
    return this._http.get<EventListModel[]>(
      this.url + 'events/geteventswithhostnames/' + searchInput
    );
  }
}
