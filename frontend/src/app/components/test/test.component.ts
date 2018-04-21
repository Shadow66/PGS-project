import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../shared/services/api.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {
  constructor(private apiService: ApiService) {}

  ngOnInit() {}
  onPostTest() {
    // JSON.stringify potrzebne jest gdy przesylamy czysty string
    this.apiService
      .postTest(JSON.stringify('fsdf'))
      .subscribe(
        response => console.log(response),
        error => console.log(error)
      );
  }
  onGetTest() {
    this.apiService
      .getTest()
      .subscribe(
        response => console.log(response),
        error => console.log(error)
      );
  }
}
