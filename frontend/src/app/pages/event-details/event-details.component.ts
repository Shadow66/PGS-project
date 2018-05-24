import { Component, OnInit, AfterContentChecked } from '@angular/core';
import { EventModel } from '../../shared/models/event.model';
import { SearchService } from '../../shared/services/search.service';
import { EventListModel } from '../../shared/models/eventList.model';
import { ActivatedRoute, Params } from '@angular/router';

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
    private searchService: SearchService
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
    this.searchService
      .getEvent(this.id)
      .subscribe(event => (this.event = event), error => console.log(error));
  }
}
