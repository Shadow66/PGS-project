import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../shared/services/api.service';
import { SearchCommunicationService } from '../../shared/search-communication.service';
import { EventListModel } from '../../shared/models/event.model';
import { SearchService } from '../../shared/services/search.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  events: EventListModel[];
  constructor(
    private apiService: ApiService,
    private searchService: SearchService,
    private searchCommuncationService: SearchCommunicationService
  ) {}

  ngOnInit() {
    this.searchCommuncationService.currentEventsList.subscribe(
      events => (this.events = events)
    );
    console.log(this.events);
  }
  onSearch(input: string) {
    this.searchService
      .getEvents(input)
      .subscribe(events => (this.events = events), error => console.log(error));
    console.log(this.events);
    this.searchCommuncationService.insertData(this.events);
  }
}
