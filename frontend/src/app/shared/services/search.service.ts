import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthenticationUserModel } from '../../shared/models/authenticationUser.model';
import { EventListModel } from '../../shared/models/eventList.model';
import { Observable } from 'rxjs/Observable';
import { EventModel } from '../models/event.model';

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
  // getEvent(id: string): observable<EventModel> {
    // return this._http.get<EventModel>(
    // this.url + id
    // );
  getEvent(id: string): EventModel {
    return new EventModel(1, 'mockHostname', 'mockAddress', new Date(), new Date(), 'mockTitle', 'mockCategory', 'mockDescription', 1);
  }
}
