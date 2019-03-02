import { Injectable } from "@angular/core";
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { AuthenticationService } from "./authentication.service";

@Injectable()
export class AuthenticationGuard {
    constructor(private router: Router,
                private authService: AuthenticationService) {}
    canActivate(route: ActivatedRouteSnapshot,
            state: RouterStateSnapshot): boolean {
                var token = localStorage.getItem("user");
                var admin = localStorage.getItem("admin");
        if (token||admin) {
            return true;
        }
        else {
            this.authService.callbackUrl = "/table" + route.url.toString();
            this.router.navigateByUrl("/login");
            return false;
        }
    }
}