import { Component, OnInit } from '@angular/core';
import { Repository } from 'src/app/models/repository';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from 'src/app/models/user-model/user.model';
import { Instruction } from 'src/app/models/instruction-model/instruction.model';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {

  constructor(private repository: Repository,
    router: Router,
    activeRoute: ActivatedRoute) { 
      let id = activeRoute.snapshot.params["id"];
      if (id) {
        this.repository.getUser(id);
      }
      else {
        router.navigateByUrl("/");
      }
     }

     get user(): User {
      return this.repository.user;
    }
  
     tableMode: boolean;
   
      get instruction(): Instruction {
          return this.repository.instruction;
      }
      selectInstruction(id: number) {
          this.repository.getInstruction(id);
      }
      saveInstruction() {
          if (this.repository.instruction.instructionId == null) {
              this.repository.createInstruction(this.repository.instruction);
          } else {
              let changes = new Map<string, any>();
              changes.set("Description", this.repository.instruction.description);
              changes.set("InstructionName", this.repository.instruction.instructionName);
              changes.set("Steps",this.repository.instruction.steps);
              changes.set("User",this.repository.instruction.user);
              this.repository.updateInstruction(this.repository.instruction.instructionId,changes);
          }
          this.clearInstruction();
      }
      deleteInstruction(id: number) {
          this.repository.deleteInstruction(id);
      }
  
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
  ngOnInit() {
  }

}
