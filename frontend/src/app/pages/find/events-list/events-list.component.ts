import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { EventListModel } from '../../../shared/models/event.model';
import { SearchCommunicationService } from '../../../shared/search-communication.service';

@Component({
  selector: 'app-events-list',
  templateUrl: './events-list.component.html',
  styleUrls: ['./events-list.component.css']
})
export class EventsListComponent implements OnInit {
  events: EventListModel[];
  constructor(private _searchCommuncationService: SearchCommunicationService) { }

  ngOnInit() {
    this._searchCommuncationService.currentEventsList.subscribe(events => this.events = events);
  }

}

