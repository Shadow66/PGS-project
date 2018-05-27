import { Component, OnInit } from '@angular/core';
import { EventService } from '../../shared/services/event.service';
import { EventListModel } from '../../shared/models/eventList.model';

@Component({
  selector: 'app-my-events-list',
  templateUrl: './my-events-list.component.html',
  styleUrls: ['./my-events-list.component.css']
})
export class MyEventsListComponent implements OnInit {
  events: EventListModel[] = [];

  constructor(private eventService: EventService) {}

  ngOnInit() {
    this.eventService
      .getMyEvents()
      .subscribe(events => (this.events = events), error => console.log(error));
  }
  onDelete(id: string) {
    this.eventService
      .deleteEvent(id)
      .subscribe(response => console.log(response), error => console.log(error));
  }
}
