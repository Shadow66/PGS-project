import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EventModel } from '../models/event.model';
import { Observable } from 'rxjs/Observable';
import { CreateEventModel } from '../models/createEvent.model';
import { EventListModel } from '../models/eventList.model';
import { EditEventModel } from '../models/editEvent.model';

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
  leaveEvent(id: string): Observable<string> {
    return this._http.post<string>(this.url + 'LeaveEvent/' + id, '');
  }
  createEvent(event: CreateEventModel): Observable<string> {
    return this._http.post<string>(this.url, event);
  }
  deleteEvent(id: string): Observable<string> {
    return this._http.delete<string>(this.url + id);
  }
  editEvent(event: EditEventModel): Observable<string> {
    return this._http.put<string>(this.url, event);
  }
  getMyEvents(): Observable<EventListModel[]> {
    return this._http.get<EventListModel[]>(this.url + 'GetMyCreatedEvents');
  }
  joinnable(id: string): Observable<string> {
    return this._http.get<string>(this.url + 'IsAssignedToEvent/' + id);
  }
}
