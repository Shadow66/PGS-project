import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { EventListModel } from '../../shared/event.model';

@Component({
  selector: 'app-events-list',
  templateUrl: './events-list.component.html',
  styleUrls: ['./events-list.component.css']
})
export class EventsListComponent implements OnInit {
  events: EventListModel[] = [
    new EventListModel(1, 'PWR', 'Address1', new Date(), 'Title1', 'cat1'),
    new EventListModel(2, 'PWR', 'Address2', new Date(), 'Title2', 'cat2'),
    new EventListModel(2, 'PWR', 'Address2', new Date(), 'Title3', 'cat2'),
    new EventListModel(2, 'PWR', 'Address2', new Date(), 'Title4', 'cat2'),
    new EventListModel(2, 'PWR', 'Address2', new Date(), 'Title5', 'cat2'),
    new EventListModel(2, 'PWR', 'Address2', new Date(), 'Title6', 'cat2')
  ];
  constructor() { }

  ngOnInit() {
  }
}
