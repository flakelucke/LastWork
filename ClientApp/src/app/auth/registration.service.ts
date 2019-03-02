import { Injectable } from "@angular/core";
import { Repository } from "../models/repository";
import { Observable } from "rxjs/Observable";
import { Router } from "@angular/router";
import "rxjs/add/observable/of";
import "rxjs/add/operator/catch";

@Injectable()
export class RegistrationService {
    constructor(private repo: Repository,
                private router: Router) { }
    authenticated: boolean = false;
    registered: boolean = false;
    email: string;
    password: string;
    callbackUrl: string;

    registration() : Observable<boolean> {
        this.authenticated = false;
        return this.repo.registration(this.email, this.password)
            .map(response => {
                if (response.ok) {
                    this.registered = true;
                    this.password = null;
                    this.router.navigateByUrl("/login");
                }
                return this.registered;
            })
            .catch(e => {
                this.registered = false;
                return Observable.of(false);  
            });
    }
}