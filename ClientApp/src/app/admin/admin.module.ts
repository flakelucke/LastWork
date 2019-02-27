import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser"
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { AdminComponent } from "./admin.component";
import { OverviewComponent } from "./overview/overview.component";
import { InstructionAdminComponent } from "./instruction-admin/instruction-admin.component";
import { InstructionEditorComponent } from "./instruction-editor/instruction-editor.component";
import { PaginationAdminComponent } from "./pagination-admin/pagination-admin.component";


@NgModule({
    imports: [BrowserModule, RouterModule, FormsModule],
    declarations: [AdminComponent, OverviewComponent,InstructionAdminComponent,InstructionEditorComponent,PaginationAdminComponent],
    providers: []
})
export class AdminModule { }