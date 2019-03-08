import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../auth/authentication.service';
import { Repository } from '../models/repository';
import { User } from '../models/user-model/user.model';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  userId: string;
  repository: Repository;
  constructor(public authService: AuthenticationService,
    private repo: Repository) {
      
    }

  public get authenticated(): boolean {
    return this.authService.isAuthenticated();
  }

  public get isAdmin(): boolean {
    return this.authService.isAdmin();
  }

  ngOnInit() {
    this.repo.getLogUser(localStorage.getItem("userId"));
  }
}
