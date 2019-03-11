import { Step } from "../step-model/step.model";
import { User } from "../user-model/user.model";

export class Instruction {
    constructor(
        public instructionId?: number,
        public instructionName?: string,
        public description?: string,
        public category? :string,
        public steps?: Step[],
        public user?: User
    )
    {}
}