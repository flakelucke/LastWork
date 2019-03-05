import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../auth/authentication.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  constructor(public authService: AuthenticationService) { }

  admin: string = localStorage.getItem("admin");

  public get authenticated() :boolean {
    return this.authService.isAuthenticated();
  }

  public get isAdmin() : boolean {
    return this.authService.isAdmin();
  }

  ngOnInit() {
  }

}
