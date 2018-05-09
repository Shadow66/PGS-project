import { Component, OnInit } from '@angular/core';
import { TestService } from '../../shared/services/test.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {
  constructor(private testService: TestService) {}

  ngOnInit() {}
  onPostTest() {
    // JSON.stringify potrzebne jest gdy przesylamy czysty string
    this.testService
      .postTest(JSON.stringify('fsdf'))
      .subscribe(
        response => console.log(response),
        error => console.log(error)
      );
  }
  onGetTest() {
    this.testService
      .getTest()
      .subscribe(
        response => console.log(response),
        error => console.log(error)
      );
  }
  onAuthTest() {
    this.testService
      .authTest()
      .subscribe(
        response => console.log(response),
        error => console.log(error)
      );
  }
}
