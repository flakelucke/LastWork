import { Instruction } from "./instruction-model/instruction.model";
import { Injectable } from "@angular/core";
import { Http, RequestMethod, Request, Response } from "@angular/http";
import { Observable } from "rxjs";
import "rxjs/add/operator/map";
import { Pagination } from "./config-classes.repository";
import { User } from "./user-model/user.model";
import { Router } from "@angular/router";
import { forEach } from "@angular/router/src/utils/collection";

const userUrl = "/api/users";
const instructionsUrl = "/api/instructions";

@Injectable()
export class Repository {
    instruction: Instruction;
    instructions: Instruction[];
    users: User[];
    logUser: User;
    user: User;
    admins: User[];
    private paginationObject = new Pagination();

    constructor(private http: Http,
        private router: Router) {
        // this.getLogUser(localStorage.getItem("userId"));
    }

    get pagination(): Pagination {
        return this.paginationObject;
    }

    getLogUser(id: string) {
        this.sendRequest(RequestMethod.Get, userUrl + "/" + id)
            .subscribe(response => {
                this.logUser = response;
            });
    }

    getUser(id: string) {
        this.sendRequest(RequestMethod.Get, userUrl + "/" + id)
            .subscribe(response => {
                this.user = response;
            });
    }

    getAdmins() {
        this.sendRequest(RequestMethod.Get, userUrl + "/admins")
            .subscribe(res => {
                this.admins = res;
                this.pagination.currentPage = 1;
            })
    }

    getUsers() {
        this.sendRequest(RequestMethod.Get, userUrl)
            .subscribe(res => {
                this.users = res;
                this.pagination.currentPage = 1;
            })
    }

    deleteUser(user: User) {
        this.sendRequest(RequestMethod.Delete, userUrl + "/" + user.id, this.logUser)
            .subscribe(() => {
                if (user.id == this.logUser.id) {
                    localStorage.removeItem("userId");
                    localStorage.removeItem("admin");
                    localStorage.removeItem("user");
                    this.logout();
                    this.router.navigateByUrl("/");
                }
                this.users.splice(this.users.indexOf(user), 1);
            })

    }

    giveAdmin(id: string) {
        this.sendRequest(RequestMethod.Post, userUrl + "/" + id)
            .subscribe(() => {
                this.users.splice(this.users.indexOf(this.users.find(x => x.id == id)), 1);
                // this.getUsers();
            })
    }

    pickUpAdmin(id: string) {
        this.sendRequest(RequestMethod.Post, userUrl + "/pick/" + id)
            .subscribe(() => {
                if (id == this.logUser.id) {
                    this.router.navigateByUrl("/");
                    localStorage.setItem("user", localStorage.getItem("admin"));
                    localStorage.removeItem("admin");
                }
                this.admins.splice(this.admins.indexOf(this.admins.find(x => x.id == id)), 1);
            })
    }
    blockUser(id:string) {
        this.sendRequest(RequestMethod.Post, userUrl + "/block/" + id)
        .subscribe(()=> {
            if (id == this.logUser.id) {
                localStorage.removeItem("admin");
                localStorage.removeItem("user");
                localStorage.removeItem("userId");
                this.router.navigateByUrl("/");
            }
            this.getUsers();
        })
    }
    blockAdmin(id:string) {
        this.sendRequest(RequestMethod.Post, userUrl + "/block/" + id)
        .subscribe(()=> {
            if (id == this.logUser.id) {
                localStorage.removeItem("admin");
                localStorage.removeItem("user");
                localStorage.removeItem("userId");
                this.router.navigateByUrl("/");
            }
            this.getAdmins();
        })
    }
    getInstructions(search: string) {
        this.sendRequest(RequestMethod.Get, instructionsUrl + (search != null ? "?search=" + search : ""))
            .subscribe(response => {
                this.instructions = response;
                this.pagination.currentPage = 1;
            })
    }

    getInstruction(id: number) {
        this.sendRequest(RequestMethod.Get, instructionsUrl + "/" + id)
            .subscribe(response => { this.instruction = response; });
    }

    createInstruction(instr: Instruction) {
        let data = {
            instructionName: instr.instructionName, description: instr.description
            , steps: instr.steps, user: this.logUser
        };
        this.sendRequest(RequestMethod.Post, instructionsUrl, data)
            .subscribe(response => {
                instr.instructionId = response;
                this.instructions.unshift(instr);
            });
    }

    deleteInstruction(id: number) {
        this.sendRequest(RequestMethod.Delete, instructionsUrl + "/" + id, this.logUser)
            .subscribe(() => {
                this.getInstructions("");
            });
    }

    updateInstruction(id: number, changes: Map<string, any>) {
        let patch = [];
        changes.forEach((value, key) =>
            patch.push({ op: "replace", path: key, value: value }));
        this.sendRequest(RequestMethod.Patch, instructionsUrl + "/" + id, patch)
            .subscribe(response => this.getInstructions(""));
    }

    login(name: string, password: string): Observable<Response> {
        return this.http.post("/api/account/login",
            { name: name, password: password });
    }
    logout() {
        this.http.post("/api/account/logout", null).subscribe(respone => { });
    }

    registration(email: string, password: string): Observable<Response> {
        return this.http.post("/api/account/register",
            { email: email, password: password });
    }



    private sendRequest(verb: RequestMethod, url: string,
        data?: any): Observable<any> {
        return this.http.request(new Request({
            method: verb, url: url, body: data
        }))
            .map(response => {
                return response.headers.get("Content-Length") != "0"
                    ? response.json() : null;
            });
    }
}
