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
    private router: Router) {
    this.repository.getInstructions();
  }

  tableMode: boolean;

  clearInstruction() {
    this.repository.instruction = new Instruction();
    this.tableMode = true;
  }

  get instructions(): Instruction[] {
    if (this.repository.instructions != null && this.repository.instructions.length > 0) {
      let pageIndex = (this.repository.pagination.currentPage - 1)
        * this.repository.pagination.productsPerPage;
      return this.repository.instructions.slice(pageIndex, pageIndex + this.repository.pagination.productsPerPage);
    }
    return this.repository.instructions;
  }

  createInstruction() {
    // this.repository.getUser(localStorage.getItem("userId"));
    this.repository.createInstruction(this.repository.instruction);
    this.clearInstruction();
  }
  ngOnInit() {
    this.tableMode = true;
  }

}
