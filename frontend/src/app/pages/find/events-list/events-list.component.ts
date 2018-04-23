import { Component, OnInit, Input, Output, EventEmitter, SimpleChanges, OnChanges } from '@angular/core';
import { EventListModel } from '../../../shared/models/event.model';
import { SearchService } from '../../../shared/services/search.service';

@Component({
  selector: 'app-events-list',
  templateUrl: './events-list.component.html',
  styleUrls: ['./events-list.component.css']
})
export class EventsListComponent implements OnInit, OnChanges {
  events: EventListModel[] = [];
  @Input() keyword: string;
  constructor(
    private searchService: SearchService) { }

  ngOnInit() {
  }
  ngOnChanges(changes: SimpleChanges) {
    console.log('alo');
    this.searchService
      .getEvents(this.keyword)
      .subscribe(events => (this.events = events), error => console.log(error));
      console.log(this.events);
    this.events.forEach(element => {
      console.log('dds');
        this.searchService.getEventParticipantNumber(element.id)
        // .subscribe(participants => console.log(participants), error => console.log(error));
         .subscribe(participants => (element.participants = participants), error => console.log(error));
      });
  }
}

