import { Component, OnInit } from '@angular/core';
import { Repository } from 'src/app/models/repository';
import { User } from 'src/app/models/user-model/user.model';

@Component({
  selector: 'app-users-admin',
  templateUrl: './users-admin.component.html',
  styleUrls: ['./users-admin.component.css']
})
export class UsersAdminComponent implements OnInit {

  constructor(private repository: Repository) {
    this.repository.getUsers();
  }

  get users(): User[] {
    if (this.repository.users != null && this.repository.users.length > 0) {
      let pageIndex = (this.repository.pagination.currentPage - 1)
        * this.repository.pagination.productsPerPage;
      return this.repository.users.slice(pageIndex, pageIndex + this.repository.pagination.productsPerPage);
    }
    return this.repository.users;
  }

  giveAdmin(id: string) {
    this.repository.giveAdmin(id);
  }

  deleteUser(user: User) {
    this.repository.deleteUser(user);
  }

  blockUser(id : string) {
    this.repository.blockUser(id);
  }
  
  ngOnInit() {
  }
}
