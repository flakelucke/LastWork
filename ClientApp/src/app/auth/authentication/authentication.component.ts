import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from "../authentication.service";

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.css']
})
export class AuthenticationComponent implements OnInit {

  constructor(public authService: AuthenticationService) { }

  showError: boolean = false;

  login() {
    this.showError = false;
    this.authService.login().subscribe(res=> {
      this.showError = !res;
    })
  }
  
  ngOnInit() {
  }

}
