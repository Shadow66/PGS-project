import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-participant',
  templateUrl: './participant.component.html',
  styleUrls: ['./participant.component.css']
})
export class ParticipantComponent implements OnInit {
  @Input() user: string;

  constructor() { }

  ngOnInit() {
  }

}
