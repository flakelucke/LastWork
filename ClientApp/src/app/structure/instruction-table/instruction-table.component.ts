import { Component, OnInit } from '@angular/core';
import { Repository } from 'src/app/models/repository';
import { Instruction } from 'src/app/models/instruction-model/instruction.model';
import { Router } from '@angular/router';
import { Step } from 'src/app/models/step-model/step.model';

@Component({
  selector: 'app-instruction-table',
  templateUrl: './instruction-table.component.html',
  styleUrls: ['./instruction-table.component.css']
})
export class InstructionTableComponent implements OnInit {

  constructor(private repository: Repository,
    private router: Router) { }

  get instructions(): Instruction[] {
    if (this.repository.instructions != null && this.repository.instructions.length > 0) {
      let pageIndex = (this.repository.pagination.currentPage - 1)
        * this.repository.pagination.productsPerPage;
      return this.repository.instructions.slice(pageIndex, pageIndex + this.repository.pagination.productsPerPage);
    }
    return this.repository.instructions;
  }

  updateInstruction() {
    let changes = new Map<string, any>();
    changes.set("Description", "Green Kayak");
    this.repository.updateInstruction(this.repository.instructions[0].instructionId, changes);
  }

  deleteInstruction() {
    this.repository.deleteInstruction(this.repository.instructions[0].instructionId);
  }

  createInstruction() {
    this.repository.createInstruction(new Instruction(0, "new instr", "See what the fish are hiding"
      , [new Step(1, "kolya", "second"), new Step(2, "kolya", "second")]
    ));
  }
  ngOnInit() {
  }

}
