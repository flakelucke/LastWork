import { Component, OnInit } from '@angular/core';
import { Repository } from '../models/repository';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit {

  constructor(private repository: Repository) { }

  get current():number {
    return this.repository.pagination.currentPage;
  }

  get pages(): number[] {
    if (this.repository.instructions != null) {
      return Array(Math.ceil(this.repository.instructions.length
        / this.repository.pagination.productsPerPage))
        .fill(0).map((x,i)=> i +1);
    }
    else {
      return [];
    }
  }

  changePage(newPage: number) {
    this.repository.pagination.currentPage = newPage;
  }

  ngOnInit() {
  }

}
