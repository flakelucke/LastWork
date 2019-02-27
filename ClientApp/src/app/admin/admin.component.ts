import { Component, OnInit } from '@angular/core';
import { Repository } from '../models/repository';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private repository: Repository) {
    this.repository.getInstructions();
   }

  ngOnInit() {
  }

}
