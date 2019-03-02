import { Component, OnInit } from '@angular/core';
import { RegistrationService } from '../registration.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  showError: boolean = false;

  constructor(public regService : RegistrationService) { }

  registration() {
    this.regService.registration().subscribe(res=>
      this.showError = !res);
  }

  ngOnInit() {
  }

}
