import { Instruction } from "../instruction-model/instruction.model";

export class User {
    constructor(
        public id: string,
        public email?: string,
        public userName?: string,
        public instruction?: Instruction
    ){}
}