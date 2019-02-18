import { Step } from "../step-model/step.model";

export class Instruction {
    constructor(
        public instructionId?: number,
        public instructionName?: string,
        public description?: string,
        public steps?: Step[]
    )
    {}
}