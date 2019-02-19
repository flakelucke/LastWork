import { Instruction } from "./instruction-model/instruction.model";
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";

@Injectable()
export class Repository
{

    constructor(private http: Http) {
         this.getInstruction(4);
    }

    getInstruction(id: number) {
        this.http.get("/api/instructions/" + id)
        .subscribe(response => this.instruction =response.json());
        }

        instruction: Instruction;

}
