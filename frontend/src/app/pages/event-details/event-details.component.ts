import { Component, OnInit, AfterContentChecked } from '@angular/core';
import { EventModel } from '../../shared/models/event.model';
import { EventListModel } from '../../shared/models/eventList.model';
import { ActivatedRoute, Params } from '@angular/router';
import { EventService } from '../../shared/services/event.service';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent implements OnInit {
  id: string;
  event: EventModel = new EventModel(
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null
  );

  constructor(
    private route: ActivatedRoute,
    private eventService: EventService
  ) {
    this.route.params.subscribe((params: Params) => {
      if (params['id'] === undefined) {
        this.id = '';
      } else {
        this.id = '' + params['id'];
      }
    });
  }

  ngOnInit(): void {
    this.eventService
      .getEvent(this.id)
      .subscribe(event => (this.event = event), error => console.log(error));
  }
  onJoin() {
    this.eventService
      .joinEvent(this.id)
      .subscribe(response => console.log(response), error => console.log(error));
  }
}
