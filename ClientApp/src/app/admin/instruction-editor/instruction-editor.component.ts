import { Component, OnInit } from '@angular/core';
import { Repository } from 'src/app/models/repository';
import { Instruction } from 'src/app/models/instruction-model/instruction.model';
import { Step } from 'src/app/models/step-model/step.model';

@Component({
  selector: 'app-instruction-editor',
  templateUrl: './instruction-editor.component.html',
  styleUrls: ['./instruction-editor.component.css']
})
export class InstructionEditorComponent implements OnInit {

  constructor(private repo: Repository) { }
    get instruction(): Instruction {
        return this.repo.instruction;
    }
    addStep() {
      if (this.repo.instruction.steps == null)
      {
        this.repo.instruction.steps = [new Step()];
      }
      else this.repo.instruction.steps.push(new Step());
    }
  ngOnInit() {
  }

}
