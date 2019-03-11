import { Component, OnInit } from '@angular/core';
import { Repository } from 'src/app/models/repository';
import { Instruction } from 'src/app/models/instruction-model/instruction.model';
import { Step } from 'src/app/models/step-model/step.model';
import { CloudinaryOptions, CloudinaryUploader } from 'ng2-cloudinary';

@Component({
  selector: 'app-instruction-editor',
  templateUrl: './instruction-editor.component.html',
  styleUrls: ['./instruction-editor.component.css']
})
export class InstructionEditorComponent implements OnInit {

  uploader: CloudinaryUploader = new CloudinaryUploader(
    new CloudinaryOptions({ cloudName: 'dsrri3kxf', uploadPreset: 'cqb8jm5v' })
  );

  loading: any;

  id: string;

  constructor(private repo: Repository) {
    this.id = localStorage.getItem("userId");
  }
  get instruction(): Instruction {
    return this.repo.instruction;
  }
  addStep() {
    if (this.repo.instruction.steps == null) {
      this.repo.instruction.steps = [new Step()];
    }
    else this.repo.instruction.steps.push(new Step());
  }
  deleteStep(step: Step) {
    this.repo.instruction.steps.splice(this.repo.instruction.steps.indexOf(step), 1);
  }
  ngOnInit() {
  }

  upload() {
    this.loading = true;
    this.uploader.uploadAll();
    this.uploader.onSuccessItem = (item: any, response: string, status: number, headers: any): any => {
      let res: any = JSON.parse(response);
      console.log(res);
    }
    this.uploader.onErrorItem = function (fileItem, response, status, headers) {
      console.info('onErrorItem', fileItem, response, status, headers);
    };
  }

}
