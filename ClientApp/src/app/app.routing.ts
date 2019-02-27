import { Routes, RouterModule } from "@angular/router";
import { InstructionTableComponent } from "./structure/instruction-table/instruction-table.component";
import { InstructionDetailComponent } from "./structure/instruction-detail/instruction-detail.component";
import { AdminComponent } from "./admin/admin.component";
import { InstructionAdminComponent } from "./admin/instruction-admin/instruction-admin.component";
import { OverviewComponent } from "./admin/overview/overview.component";

const routes: Routes = [
    {
        path: "admin", component: AdminComponent,
        children: [
            { path: "instructions", component: InstructionAdminComponent },
            { path: "overview", component: OverviewComponent },
            { path: "", component: OverviewComponent }
        ]
    },
    { path: "table", component: InstructionTableComponent },
    { path: "detail/:id", component: InstructionDetailComponent },
    { path: "detail", component: InstructionDetailComponent },
    { path: "", component: InstructionTableComponent }]

export const RoutingConfig = RouterModule.forRoot(routes);