import { Component } from '@angular/core';
import { Repository } from "./models/repository";
import { Instruction } from "./models/instruction-model/instruction.model";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { Step } from './models/step-model/step.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  constructor(private repository: Repository) { }

  get instruction(): Instruction {
    return this.repository.instruction;
  }

  get instructions(): Instruction[] {
    return this.repository.instructions;
  }
  
}
