import { Instruction } from "./instruction-model/instruction.model";
import { Injectable } from "@angular/core";
import { Http, RequestMethod, Request, Response } from "@angular/http";
import { Observable } from "rxjs";
import "rxjs/add/operator/map";
import { Pagination } from "./config-classes.repository";

const instructionsUrl = "/api/instructions";

@Injectable()
export class Repository {
     instruction: Instruction;
     instructions: Instruction[];
    private paginationObject = new Pagination();

    constructor(private http: Http) {
        this.getInstructions();
    }

    get pagination(): Pagination {
        return this.paginationObject;
    }

    getInstructions() {
        this.sendRequest(RequestMethod.Get, instructionsUrl)
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
            ,steps: instr.steps
        };
        this.sendRequest(RequestMethod.Post, instructionsUrl, data)
            .subscribe(response => {
                instr.instructionId = response;
                this.instructions.push(instr);
            });
    }

    deleteInstruction(id: number) {
        this.sendRequest(RequestMethod.Delete, instructionsUrl + "/" + id)
            .subscribe(() => {
               this.getInstructions();
            });
    }

    updateInstruction(id: number, changes: Map<string, any>) {
        let patch = [];
        changes.forEach((value, key) =>
            patch.push({ op: "replace", path: key, value: value }));
        this.sendRequest(RequestMethod.Patch, instructionsUrl + "/" + id, patch)
            .subscribe(response => this.getInstructions());
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
