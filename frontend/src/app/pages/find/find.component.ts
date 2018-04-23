import { Component, OnInit, AfterContentChecked, SimpleChanges, OnChanges } from '@angular/core';
import { EventListModel } from '../../shared/models/event.model';
import { ActivatedRoute, Params } from '@angular/router';
import { SearchService } from '../../shared/services/search.service';
import { ApiService } from '../../shared/services/api.service';

@Component({
  selector: 'app-find',
  templateUrl: './find.component.html',
  styleUrls: ['./find.component.css']
})
export class FindComponent implements OnInit {
  keyword: string;
  constructor(
    private apiService: ApiService,
    private route: ActivatedRoute,
  ) {
    this.route.params.subscribe((params: Params) => {
      if (params['keyword'] === undefined) {
        this.keyword = '';
      } else {
        this.keyword = '' + params['keyword'];
      }
    });
  }

  ngOnInit() {
  }
}
