import { Component } from '@angular/core';
import { Repository } from "./models/repository";
import { Instruction } from "./models/instruction-model/instruction.model";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  private lastError: string[];

  constructor() {}
}
