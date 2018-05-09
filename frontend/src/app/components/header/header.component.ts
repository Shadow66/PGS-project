import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../shared/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  show = false;

  constructor(public authService: AuthService) {}

  ngOnInit() {}
  onLogout() {
    this.authService.logout();
  }

  toggleCollapse() {
    this.show = !this.show;
  }
}
