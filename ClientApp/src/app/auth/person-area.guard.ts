import { Injectable } from "@angular/core";
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot, ActivatedRoute } from "@angular/router";
import { AuthenticationService } from "./authentication.service";
import { Repository } from "../models/repository";

@Injectable()
export class PersonAreaGuard {
    constructor(private router: Router,
        private authService: AuthenticationService) { }

    canActivate(route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot,
        repo: Repository): boolean {
        var id = state.url.includes(localStorage.getItem("userId"));
        var admin = localStorage.getItem("admin");
        if (id || admin) {
            return true;
        }
        else {
            this.authService.callbackUrl = "/table" + route.url.toString();
            this.router.navigateByUrl("/");
            return false;
        }
    }
}