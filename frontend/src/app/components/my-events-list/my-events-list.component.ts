import { Component, OnInit } from '@angular/core';
import { EventService } from '../../shared/services/event.service';
import { EventListModel } from '../../shared/models/eventList.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-my-events-list',
  templateUrl: './my-events-list.component.html',
  styleUrls: ['./my-events-list.component.css']
})
export class MyEventsListComponent implements OnInit {
  events: EventListModel[] = [];

  constructor(private eventService: EventService, private router: Router) {}

  ngOnInit() {
    this.eventService
      .getMyEvents()
      .subscribe(events => (this.events = events), error => console.log(error));
  }
  onDelete(id: string, ind) {
    this.eventService
      .deleteEvent(id)
      .subscribe(
        response => console.log(response),
        error => console.log(error)
      );
      this.events.splice(ind, 1);
  }
  onEdit(input: string) {
    console.log(input);
    this.router.navigateByUrl('/edit/' + input);
  }
}
