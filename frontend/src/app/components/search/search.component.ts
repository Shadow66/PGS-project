import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../shared/api.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  constructor(private apiService: ApiService) { }

  ngOnInit() {
  }
  onSearch(input: string) {
    this.apiService
      .getEvents(input)
      .subscribe(
        response => console.log(response),
        error => console.log(error)
      );
  }
}
