import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../shared/services/api.service';
import { EventListModel } from '../../shared/models/event.model';
import { SearchService } from '../../shared/services/search.service';
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
