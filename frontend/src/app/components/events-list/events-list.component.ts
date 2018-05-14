import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { EventListModel } from '../../shared/models/eventList.model';
import { SearchService } from '../../shared/services/search.service';

@Component({
  selector: 'app-events-list',
  templateUrl: './events-list.component.html',
  styleUrls: ['./events-list.component.css']
})
export class EventsListComponent implements OnInit, OnChanges {
  events: EventListModel[] = [];
  showSortList = false;
  @Input() keyword: string;
  constructor(private searchService: SearchService) {}

  ngOnInit() {}
  ngOnChanges() {
    this.searchService
      .getEvents(this.keyword)
      .subscribe(events => (this.events = events), error => console.log(error));
  }
  toggleCollapse() {
    this.showSortList = !this.showSortList;
  }
  onSortAsc() {
    this.events.sort(this.sortAsc);
  }
  sortAsc(e1: EventListModel, e2: EventListModel) {
    if (e1.startDate > e2.startDate) {
      return 1;
    } else if (e1.startDate === e2.startDate) {
      return 0;
    } else {
      return -1;
    }
  }
  onSortDesc() {
    this.events.sort(this.sortDesc);
  }

  sortDesc(e1: EventListModel, e2: EventListModel) {
  if (e1.startDate < e2.startDate) {
    return 1;
  } else if (e1.startDate === e2.startDate) {
    return 0;
  } else {
    return -1;
  }
}
}
