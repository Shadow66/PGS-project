import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';

@Injectable()
export class ApiService {

  constructor(private http: Http) { }
  url = 'http://localhost:54376/api/values';

  getTest() {
    return this.http.get(this.url);
  }

  postTest(message: String) {
    const headers = new Headers({'Content-Type': 'application/json'});
    return this.http.post(this.url,
      message,
      {headers: headers});
  }
}
