import { Component, OnInit, Input } from '@angular/core';
import { EventService } from '../../shared/services/event.service';

@Component({
  selector: 'app-join',
  templateUrl: './join.component.html',
  styleUrls: ['./join.component.css']
})
export class JoinComponent implements OnInit {
  @Input() joinnable: boolean;
  @Input() id;

  constructor(private eventService: EventService) {}

  ngOnInit() {}

  onJoin() {
    this.eventService
      .joinEvent(this.id)
      .subscribe(
        response => console.log(response),
        error => console.log(error)
      );
      this.joinnable = false;
  }
  onLeave() {
    this.eventService
      .leaveEvent(this.id)
      .subscribe(
        response => console.log(response),
        error => console.log(error)
      );
      this.joinnable = true;
  }
}
