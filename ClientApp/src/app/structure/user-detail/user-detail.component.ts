import { Component, OnInit } from '@angular/core';
import { Repository } from 'src/app/models/repository';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from 'src/app/models/user-model/user.model';

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

  ngOnInit() {
  }

}
