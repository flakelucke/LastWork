import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser"
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { AdminComponent } from "./admin.component";
import { OverviewComponent } from "./overview/overview.component";
import { InstructionAdminComponent } from "./instruction-admin/instruction-admin.component";
import { InstructionEditorComponent } from "./instruction-editor/instruction-editor.component";
import { PaginationAdminComponent } from "./pagination-admin/pagination-admin.component";
import { UsersAdminComponent } from "./users-admin/users-admin.component";
import { AdminsAdminComponent } from "./admins-admin/admins-admin.component";
import { CategoryFilterComponent } from '../structure/category-filter/category-filter.component';


@NgModule({
    imports: [BrowserModule, RouterModule, FormsModule],
    declarations: [AdminComponent,
        OverviewComponent,
        InstructionAdminComponent,
        InstructionEditorComponent,
        PaginationAdminComponent,
        UsersAdminComponent,
        AdminsAdminComponent,
        CategoryFilterComponent],
    providers: [],
    exports: [
        InstructionEditorComponent,
        InstructionAdminComponent,
        PaginationAdminComponent,
        CategoryFilterComponent
    ]
})
export class AdminModule { }