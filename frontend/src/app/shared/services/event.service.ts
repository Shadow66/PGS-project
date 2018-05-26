import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EventModel } from '../models/event.model';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class EventService {
  constructor(private _http: HttpClient) {}
  url = 'events/';

  getEvent(id: string): Observable<EventModel> {
    return this._http.get<EventModel>(this.url + 'GetEventWithHostName/' + id);
  }
  getParticipants(id: string): Observable<string> {
    return this._http.get<string>(this.url + 'GetUsersAssignedToEvent/' + id);
  }
  joinEvent(id: string): Observable<string> {
    return this._http.post<string>(this.url + 'JoinToEvent/' + id, '');
  }
}
