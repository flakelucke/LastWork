import { Instruction } from "../instruction-model/instruction.model";

export class User {
    constructor(
        public id: string,
        public email?: string,
        public userName?: string,
        public emailConfirmed? : boolean,
        public isBlocked?: boolean,
        public instructions?: Instruction[]
    ){}
}