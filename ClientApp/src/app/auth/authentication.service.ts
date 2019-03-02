import { Injectable } from "@angular/core";
import { Repository } from "../models/repository";
import { Observable } from "rxjs/Observable";
import { Router } from "@angular/router";
import "rxjs/add/observable/of";
import "rxjs/add/operator/catch";
import { Body } from "@angular/http/src/body";

@Injectable()
export class AuthenticationService {
    constructor(private repo: Repository,
                private router: Router) { }
    authenticated: boolean = false;
    name: string;
    password: string;
    callbackUrl: string;
    login() : Observable<boolean> {
        this.authenticated = false;
        return this.repo.login(this.name, this.password)
            .map(response => {
                if (response.ok) {
                    this.authenticated = true;
                    if (response.text()=="admin")
                    localStorage.setItem("admin", response.text());
                    else localStorage.setItem("user",response.text());
                    this.password = null;
                    console.log(this.callbackUrl);
                    this.router.navigateByUrl(this.callbackUrl || "/table");
                }
                return this.authenticated;
            })
            .catch(e => {
                localStorage.removeItem("admin");
                localStorage.removeItem("user");
                this.authenticated = false;
                return Observable.of(false);  
            });
    }
    logout() {
        this.authenticated = false;
        localStorage.removeItem("admin");
        localStorage.removeItem("user");
        this.repo.logout();
        this.router.navigateByUrl("/login");
    }
}