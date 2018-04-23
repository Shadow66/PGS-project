import { Component, OnInit, Input, Output, EventEmitter, SimpleChanges, OnChanges } from '@angular/core';
import { EventListModel } from '../../../../shared/models/event.model';
import { SearchService } from '../../../../shared/services/search.service';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent implements OnInit, OnChanges {
  @Input() event: EventListModel;

  constructor(private searchService: SearchService) {}

  ngOnInit() {}
  ngOnChanges(changes: SimpleChanges) {
    this.searchService.getEventParticipantNumber(this.event.id)
     .subscribe(participants => (this.event.participants = participants), error => console.log(error));
  }
}
