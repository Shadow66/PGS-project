import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';

@Injectable()
export class ApiService {

  constructor(private http: Http) { }
  url = 'http://localhost:54377/api/';

  getTest() {
    return this.http.get(this.url + 'values');
  }

  postTest(message: string) {
    const headers = new Headers({'Content-Type': 'application/json'});
    return this.http.post(this.url + 'values',
      message,
      {headers: headers});
  }

  getEvents(searchInput: string) {
    return this.http.get(this.url + 'events/' + searchInput);
  }
}
