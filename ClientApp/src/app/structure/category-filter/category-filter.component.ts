import { Component, OnInit } from '@angular/core';
import { Repository } from 'src/app/models/repository';
import { AuthenticationService } from 'src/app/auth/authentication.service';

@Component({
  selector: 'app-category-filter',
  templateUrl: './category-filter.component.html',
  styleUrls: ['./category-filter.component.css']
})
export class CategoryFilterComponent implements OnInit {

  constructor(public authService: AuthenticationService,
    private repo: Repository) { }

  public get authenticated(): boolean {
    return this.authService.isAuthenticated();
  }

  get currentCategory(): string {
    return this.repo.filter.category;
  }
  setCurrentCategory(newCategory: string) {
    this.repo.filter.category = newCategory;
    this.repo.getInstructions("");
    
  }

  ngOnInit() {}
}
