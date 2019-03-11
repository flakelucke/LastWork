import { Component, OnInit } from '@angular/core';
import { Repository } from 'src/app/models/repository';
import { Instruction } from 'src/app/models/instruction-model/instruction.model';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent implements OnInit {

  constructor(private repo: Repository) {
    this.repo.getInstructions("",null);
   }

  get instructions(): Instruction[] {
    return this.repo.instructions;
  }

  ngOnInit() {
  }

}
