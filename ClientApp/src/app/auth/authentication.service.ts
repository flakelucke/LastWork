import { Injectable } from "@angular/core";
import { Repository } from "../models/repository";
import { Observable } from "rxjs/Observable";
import { Router } from "@angular/router";
import "rxjs/add/observable/of";
import "rxjs/add/operator/catch";
import { debug } from "util";

@Injectable()
export class AuthenticationService {
    constructor(private repo: Repository,
        private router: Router) { }
    authenticated: boolean = false;
    name: string;
    password: string;
    callbackUrl: string;
    login(): Observable<boolean> {
        this.authenticated = false;
        return this.repo.login(this.name, this.password)
            .map(response => {
                if (response.ok) {
                    this.authenticated = true;
                    if (response.text().indexOf("admin") > -1)
                        localStorage.setItem("admin", response.text());
                    else { localStorage.setItem("user", response.text()); }
                    this.password = null;
                    localStorage.setItem("userId", response.text().slice(6));
                    this.router.navigateByUrl(this.callbackUrl || "/table");
                }
                this.repo.getLogUser(localStorage.getItem("userId"));
                return this.authenticated;
            })
            .catch(e => {
                localStorage.removeItem("admin");
                localStorage.removeItem("user");
                localStorage.removeItem("userId");
                this.authenticated = false;
                return Observable.of(false);
            });
    }
    logout() {
        this.authenticated = false;
        localStorage.removeItem("userId");
        localStorage.removeItem("admin");
        localStorage.removeItem("user");
        this.repo.logout();
        this.router.navigateByUrl("/login");
    }

    public isAuthenticated(): boolean {
        if (localStorage.getItem("user") || localStorage.getItem("admin"))
            return true;
        else return false;
    }

    public isAdmin(): boolean {
        if (localStorage.getItem("admin"))
            return true;
        return false;
    }
}