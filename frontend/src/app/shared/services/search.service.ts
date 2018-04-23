import { Injectable } from '@angular/core';
import { ApiService } from '../../shared/services/api.service';
import { HttpClient } from '@angular/common/http';
import { AuthenticationUserModel } from '../../shared/models/authenticatonUser.model';
import { EventListModel } from '../../shared/models/event.model';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class SearchService {
  constructor(private apiService: ApiService, private _http: HttpClient) {}
  url = 'events/';

  getEvents(searchInput: string): Observable<EventListModel[]> {
    return this._http.get<EventListModel[]>(
      this.apiService.url + this.url + 'geteventswithhostnames/' + searchInput
    );
  }
  getEventParticipantNumber(eventId: number): Observable<number> {
    return this._http.get<number>(
      this.apiService.url + this.url + 'GetNumberEventParticipants/' + eventId
    );
  }
}
