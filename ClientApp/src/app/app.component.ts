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

   deleteInstruction() {
    this.repository.deleteInstruction(this.repository.instructions[0].instructionId);
    }

  createInstruction() {
    this.repository.createInstruction(new Instruction(0, "new instr", "See what the fish are hiding"
      , [new Step(1, "kolya", "second"), new Step(2, "kolya", "second")]
    ));

  }
}
