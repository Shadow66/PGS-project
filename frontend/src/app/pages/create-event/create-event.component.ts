import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EventService } from '../../shared/services/event.service';
import { CreateEventModel } from '../../shared/models/createEvent.model';
import { Category } from '../../shared/enums/category.enum';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styleUrls: ['./create-event.component.css']
})
export class CreateEventComponent implements OnInit {
  categories = Category;

  constructor(private eventService: EventService, private router: Router) {}

  ngOnInit() {}
  onCreate(form: NgForm) {
    const event: CreateEventModel = new CreateEventModel(
      form.value.address,
      form.value.startDate,
      form.value.endDate,
      form.value.title,
      form.value.category,
      form.value.description
    );
    this.eventService
      .createEvent(event)
      .subscribe(
        response => console.log(response),
        error => console.log(error)
      );
    setTimeout(() => {
      this.router.navigate(['/myevents/']);
    }, 100);
  }
}
