import { Component, OnInit } from '@angular/core';
import { Category } from '../../shared/enums/category.enum';
import { CreateEventModel } from '../../shared/models/createEvent.model';
import { NgForm } from '@angular/forms';
import { EventService } from '../../shared/services/event.service';
import { EditEventModel } from '../../shared/models/editEvent.model';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-edit-event',
  templateUrl: './edit-event.component.html',
  styleUrls: ['./edit-event.component.css']
})
export class EditEventComponent implements OnInit {
  categories = Category;
  category: Category;
  id;
  eventDetails = new EditEventModel(null, null, null, null, null, null, null);

  constructor(
    private eventService: EventService,
    private route: ActivatedRoute
  ) {
    this.route.params.subscribe((params: Params) => {
      if (params['id'] === undefined) {
        this.id = '';
      } else {
        this.id = '' + params['id'];
      }
    });
    this.eventService
      .getEvent(this.id)
      .subscribe(
        event => (this.eventDetails = event),
        error => console.log(error)
      );
  }

  ngOnInit() {}
  onEdit(form: NgForm) {
    const event: EditEventModel = new EditEventModel(
      this.eventDetails.id,
      this.eventDetails.address,
      this.eventDetails.startDate,
      this.eventDetails.endDate,
      this.eventDetails.title,
      this.eventDetails.category,
      this.eventDetails.description
    );
    this.eventService
      .editEvent(event)
      .subscribe(
        response => console.log(response),
        error => console.log(error)
      );
  }
}
