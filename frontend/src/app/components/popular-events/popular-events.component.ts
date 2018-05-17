import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { EventListModel } from '../../shared/models/eventList.model';
import { SearchService } from '../../shared/services/search.service';

@Component({
  selector: 'app-popular-events',
  templateUrl: './popular-events.component.html',
  styleUrls: ['./popular-events.component.css']
})
export class PopularEventsComponent implements OnInit {
  events: EventListModel[] = [];
  constructor(private searchService: SearchService) {}

  ngOnInit() {
    this.searchService
      .getPopularEvents()
      .subscribe(events => (this.events = events), error => console.log(error));
  }
}
