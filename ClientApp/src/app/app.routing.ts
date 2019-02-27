import { Routes, RouterModule } from "@angular/router";
import { InstructionTableComponent } from "./structure/instruction-table/instruction-table.component";
import { InstructionDetailComponent } from "./structure/instruction-detail/instruction-detail.component";

const routes: Routes = [
    { path: "table", component: InstructionTableComponent },
    { path: "detail/:id",component: InstructionDetailComponent},
    { path: "detail", component: InstructionDetailComponent},
    { path: "", component: InstructionTableComponent }]      

export const RoutingConfig = RouterModule.forRoot(routes);