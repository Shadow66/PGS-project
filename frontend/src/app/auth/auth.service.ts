import { Injectable } from '@angular/core';
import { ApiService } from '../shared/api.service';
import { HttpClient } from '@angular/common/http';
import { AuthenticationUserModel } from '../shared/models/authenticatonUser.model';

@Injectable()
export class AuthService {

  constructor(private apiService: ApiService, private _http: HttpClient) { }
  url = 'Authorize/Register';

  signupUser(email: string, password: string) {
      // const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
      const  user: AuthenticationUserModel = new AuthenticationUserModel(email, password);
      return this._http.post(this.apiService.url + this.url, user);
    }

}
