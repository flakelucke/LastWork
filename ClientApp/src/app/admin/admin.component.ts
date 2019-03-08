import { Component, OnInit } from '@angular/core';
import { Repository } from '../models/repository';
import { AuthenticationService } from "../auth/authentication.service";

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private repo: Repository,
    public authService: AuthenticationService) {
      
    this.repo.getInstructions("");
  }

  ngOnInit() {
  }

}
