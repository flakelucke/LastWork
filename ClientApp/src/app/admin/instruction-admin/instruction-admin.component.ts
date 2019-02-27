import { Component, OnInit } from '@angular/core';
import { Repository } from 'src/app/models/repository';
import { Instruction } from 'src/app/models/instruction-model/instruction.model';

@Component({
  selector: 'app-instruction-admin',
  templateUrl: './instruction-admin.component.html',
  styleUrls: ['./instruction-admin.component.css']
})
export class InstructionAdminComponent implements OnInit {

  constructor(private repo: Repository) { }

  tableMode: boolean = true;
    get instruction(): Instruction {
        return this.repo.instruction;
    }
    selectInstruction(id: number) {
        this.repo.getInstruction(id);
    }
    saveInstruction() {
        if (this.repo.instruction.instructionId == null) {
            this.repo.createInstruction(this.repo.instruction);
        } else {
            let changes = new Map<string, any>();
            changes.set("Description", this.repo.instruction.description);
            changes.set("InstructionName", this.repo.instruction.instructionName);
            changes.set("Steps",this.repo.instruction.steps);
            this.repo.updateInstruction(this.repo.instruction.instructionId,changes);
        }
        this.clearInstruction()
        this.tableMode = true;
    }
    deleteInstruction(id: number) {
        this.repo.deleteInstruction(id);
    }

    clearInstruction() {
      this.repo.instruction = new Instruction();
      this.tableMode = true;
  }
  get instructions(): Instruction[] {
    if (this.repo.instructions != null && this.repo.instructions.length > 0) {
        let pageIndex = (this.repo.pagination.currentPage - 1)
          * this.repo.pagination.productsPerPage;
        return this.repo.instructions.slice(pageIndex, pageIndex + this.repo.pagination.productsPerPage);
      }
      return this.repo.instructions;
  }

  ngOnInit() {
  }

}
