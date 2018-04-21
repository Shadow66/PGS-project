import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { EventListModel } from '../../../../shared/models/event.model';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent implements OnInit {
  @Input() event: EventListModel;

  constructor() { }

  ngOnInit() {
  }
}
