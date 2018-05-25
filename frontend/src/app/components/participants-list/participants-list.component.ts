import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { EventService } from '../../shared/services/event.service';

@Component({
  selector: 'app-participants-list',
  templateUrl: './participants-list.component.html',
  styleUrls: ['./participants-list.component.css']
})
export class ParticipantsListComponent implements OnInit, OnChanges {
  @Input() eventId: string;
  users: string;

  constructor(private eventService: EventService) { }

  ngOnInit() {
  }
  ngOnChanges() {
    this.eventService
      .getParticipants(this.eventId)
      .subscribe(users => (this.users = users), error => console.log(error));
  }
}
