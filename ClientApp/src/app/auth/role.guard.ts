import { Injectable } from "@angular/core";
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { AuthenticationService } from "./authentication.service";

@Injectable()
export class RoleGuard {
    constructor(private router: Router,
                private authService: AuthenticationService) {}
    canActivateChild(route: ActivatedRouteSnapshot,
            state: RouterStateSnapshot): boolean {
                var admin = localStorage.getItem("admin");
        if (admin) {
            return true;
        }
        else {
            this.authService.callbackUrl = "/admin/" + route.url.toString();
            this.router.navigateByUrl("/table");
            return false;
        }
    }
}