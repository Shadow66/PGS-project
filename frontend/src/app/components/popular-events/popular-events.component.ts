import { Component, OnInit, Input, Output, EventEmitter, SimpleChanges, OnChanges } from '@angular/core';
import { EventListModel } from '../../shared/models/event.model';
import { SearchService } from '../../shared/services/search.service';

@Component({
  selector: 'app-popular-events',
  templateUrl: './popular-events.component.html',
  styleUrls: ['./popular-events.component.css']
})
export class PopularEventsComponent implements OnInit, OnChanges {
  events: EventListModel[] = [];
  constructor(private searchService: SearchService) { }

  ngOnInit() {
    this.searchService
      .getPopularEvents()
      .subscribe(events => (this.events = events), error => console.log(error));
  }
  ngOnChanges(changes: SimpleChanges) {}

}
