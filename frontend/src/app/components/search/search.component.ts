import { Component, OnInit } from '@angular/core';
import { EventListModel } from '../../shared/models/event.model';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  constructor(private router: Router, private route: ActivatedRoute) {}

  ngOnInit() {}
  onSearch(input: string) {
    console.log(input);
    if (input === undefined) {
      input = '';
    }
    this.router.navigateByUrl('/find/' + input);
  }
}
