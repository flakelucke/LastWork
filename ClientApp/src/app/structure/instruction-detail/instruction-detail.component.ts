import { Component, OnInit } from '@angular/core';
import { Repository } from 'src/app/models/repository';
import { Instruction } from 'src/app/models/instruction-model/instruction.model';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-instruction-detail',
  templateUrl: './instruction-detail.component.html',
  styleUrls: ['./instruction-detail.component.css']
})
export class InstructionDetailComponent implements OnInit {

  constructor(private repository: Repository,
    router: Router,
    activeRoute: ActivatedRoute) {
      let id = Number.parseInt(activeRoute.snapshot.params["id"]);
      if (id) {
        this.repository.getInstruction(id);
      }
      else {
        router.navigateByUrl("/");
      }
  }

  get instruction(): Instruction {
    return this.repository.instruction;
  }

  ngOnInit() {
  }

}
