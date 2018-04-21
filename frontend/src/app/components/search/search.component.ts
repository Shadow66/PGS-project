import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../shared/api.service';
import { SearchCommunicationService } from '../../shared/search-communication.service';
import { EventListModel } from '../../shared/models/event.model';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  events: EventListModel[];
  constructor(private apiService: ApiService,  private _searchCommuncationService: SearchCommunicationService) { }

  ngOnInit() {
     this._searchCommuncationService.currentEventsList.subscribe(events => this.events = events);
     console.log(this.events);
  }
  onSearch(input: string) {
    this.apiService
      .getEvents(input)
      .subscribe(
        events => this.events = events,
        error => console.log(error)
      );
      console.log(this.events);
      this._searchCommuncationService.insertData(this.events);
  }
}
