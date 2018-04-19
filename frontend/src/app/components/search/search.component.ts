import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../shared/api.service';
import { SearchCommunicationService } from '../../shared/search-communication.service';
import { EventListModel } from '../../shared/event.model';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  events: EventListModel[] = [];
  eventm: EventListModel = new EventListModel(1, 'PWR', 'Address1', new Date(), 'Title1', 'cat1');
  constructor(private apiService: ApiService,  private _searchCommuncationService: SearchCommunicationService) { }

  ngOnInit() {
    this._searchCommuncationService.currentMessage.subscribe(events => this.events = events);
  }
  onSearch(input: string) {
    this.apiService
      .getEvents(input)
      .subscribe(
        response => console.log(response.json()),
        error => console.log(error)
      );
      this.events  = [
        new EventListModel(1, 'PWR', 'Address1', new Date(), 'Title1', 'cat1'),
        new EventListModel(2, 'PWR', 'Address2', new Date(), 'Title2', 'cat2'),
        new EventListModel(2, 'PWR', 'Address2', new Date(), 'Title3', 'cat2'),
        new EventListModel(2, 'PWR', 'Address2', new Date(), 'Title4', 'cat2'),
        new EventListModel(2, 'PWR', 'Address2', new Date(), 'Title5', 'cat2'),
        new EventListModel(2, 'PWR', 'Address2', new Date(), 'Title6', 'cat2')
      ];
      this._searchCommuncationService.insertData(this.events);
  }
}
