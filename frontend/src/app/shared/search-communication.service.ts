import { Injectable } from '@angular/core';
import { EventListModel } from './event.model';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class SearchCommunicationService {

  private events = new BehaviorSubject<EventListModel[]>([]);
  currentMessage = this.events.asObservable();

  insertData(events: EventListModel[]) {
    this.events.next(events);
  }

}
