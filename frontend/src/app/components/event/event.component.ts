import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { EventListModel } from '../../shared/models/eventList.model';
import { SearchService } from '../../shared/services/search.service';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent implements OnInit, OnChanges {
  @Input() event: EventListModel;

  constructor(private searchService: SearchService) {}

  ngOnInit() {}
  ngOnChanges() {
    this.searchService
      .getEventParticipantNumber(this.event.id)
      .subscribe(
        participants => (this.event.participants = participants),
        error => console.log(error)
      );
  }
}
