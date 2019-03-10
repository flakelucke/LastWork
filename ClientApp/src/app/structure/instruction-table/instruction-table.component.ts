import { Component, OnInit } from '@angular/core';
import { Repository } from 'src/app/models/repository';
import { Instruction } from 'src/app/models/instruction-model/instruction.model';
import { Router, ActivatedRoute } from '@angular/router';
import { Step } from 'src/app/models/step-model/step.model';
import 'rxjs/add/operator/filter';
import { AuthenticationService } from 'src/app/auth/authentication.service';

@Component({
  selector: 'app-instruction-table',
  templateUrl: './instruction-table.component.html',
  styleUrls: ['./instruction-table.component.css']
})
export class InstructionTableComponent implements OnInit {

  searchString: string = "";

  constructor(private repository: Repository,
    private router: Router,
    activeRoute: ActivatedRoute,
    public authService: AuthenticationService) {
    activeRoute.queryParams
      .filter(p => p.search)
      .subscribe(x => {
        this.searchString = x.search;
        this.repository.getInstructions(this.searchString);
      });
  }

  tableMode: boolean;
  
  public get authenticated(): boolean {
    return this.authService.isAuthenticated();
  }

  clearInstruction() {
    this.repository.instruction = new Instruction();
    this.tableMode = true;
  }

  searchInstructions(search: string) {
    if (search == null || search == undefined || search.length < 1)
      this.router.navigateByUrl("table?search=" + " ");
    else
      this.router.navigateByUrl("table?search=" + search);
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
    this.repository.createInstruction(this.repository.instruction);
    this.clearInstruction();
  }
  ngOnInit() {
    this.tableMode = true;
    if(this.searchString==null||this.searchString=="")
    this.repository.getInstructions(this.searchString);
  }

}
