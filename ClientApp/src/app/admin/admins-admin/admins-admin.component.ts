import { Component, OnInit } from '@angular/core';
import { Repository } from 'src/app/models/repository';
import { User } from 'src/app/models/user-model/user.model';

@Component({
  selector: 'app-admins-admin',
  templateUrl: './admins-admin.component.html',
  styleUrls: ['./admins-admin.component.css']
})
export class AdminsAdminComponent implements OnInit {

  constructor(private repository: Repository) {
    this.repository.getAdmins();
  }

  get admins(): User[] {
    if (this.repository.admins != null && this.repository.admins.length > 0) {
      let pageIndex = (this.repository.pagination.currentPage - 1)
        * this.repository.pagination.productsPerPage;
      return this.repository.admins.slice(pageIndex, pageIndex + this.repository.pagination.productsPerPage);
    }
    return this.repository.admins;
  }

  pickUpAdmin(id: string) {
    this.repository.pickUpAdmin(id);
  }

  deleteUser(user: User) {
    this.repository.deleteUser(user);
  }

  blockAdmin(id : string) {
    this.repository.blockAdmin(id);
  }
  ngOnInit() {
  }

}
