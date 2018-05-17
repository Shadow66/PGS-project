import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { SearchService } from '../../shared/services/search.service';

@Component({
  selector: 'app-find',
  templateUrl: './find.component.html',
  styleUrls: ['./find.component.css']
})
export class FindComponent implements OnInit {
  keyword: string;
  constructor(private route: ActivatedRoute) {
    this.route.params.subscribe((params: Params) => {
      if (params['keyword'] === undefined) {
        this.keyword = '';
      } else {
        this.keyword = '' + params['keyword'];
      }
    });
  }

  ngOnInit() {}
}
