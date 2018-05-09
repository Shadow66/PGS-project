import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthenticationUserModel } from '../../shared/models/authenticatonUser.model';
import { EventListModel } from '../../shared/models/event.model';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class SearchService {
  constructor(private _http: HttpClient) {}
  url = 'events/';

  getEvents(searchInput: string): Observable<EventListModel[]> {
    return this._http.get<EventListModel[]>(
      this.url + 'geteventswithhostnames/' + searchInput
    );
  }
  getEventParticipantNumber(eventId: number): Observable<number> {
    return this._http.get<number>(
      this.url + 'GetNumberEventParticipants/' + eventId
    );
  }
  getPopularEvents(): Observable<EventListModel[]> {
    return this._http.get<EventListModel[]>(this.url + 'GetMostPopularEvents/');
  }
}
