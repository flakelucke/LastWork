import { Routes, RouterModule } from "@angular/router";
import { InstructionTableComponent } from "./structure/instruction-table/instruction-table.component";
import { InstructionDetailComponent } from "./structure/instruction-detail/instruction-detail.component";
import { AdminComponent } from "./admin/admin.component";
import { InstructionAdminComponent } from "./admin/instruction-admin/instruction-admin.component";
import { OverviewComponent } from "./admin/overview/overview.component";
import { AuthenticationComponent } from "./auth/authentication/authentication.component";
import { AuthenticationGuard } from "./auth/authentication.guard";
import { RegisterComponent } from "./auth/register/register.component";
import { RoleGuard } from "./auth/role.guard";
import { UsersAdminComponent } from "./admin/users-admin/users-admin.component";
import { UserDetailComponent } from "./structure/user-detail/user-detail.component";
import { AdminsAdminComponent } from "./admin/admins-admin/admins-admin.component";
import { PersonAreaGuard } from "./auth/person-area.guard";

const routes: Routes = [
    { path: "login", component: AuthenticationComponent },
    { path: "register", component: RegisterComponent },
    { path: "admin", redirectTo: "/admin/overview", pathMatch: "full" },
    {
        path: "admin", component: AdminComponent,
        canActivateChild: [RoleGuard],
        children: [
            { path: "instructions", component: InstructionAdminComponent },
            { path: "users", component: UsersAdminComponent },
            { path: "admins", component: AdminsAdminComponent },
            { path: "overview", component: OverviewComponent },
            { path: "", component: OverviewComponent }

        ]
    },
    { path: "table", component: InstructionTableComponent},
    { path: "table?search=:searchString", component: InstructionTableComponent},
    { path: "user/:id", component: UserDetailComponent, canActivate: [AuthenticationGuard,PersonAreaGuard]},
    { path: "detail/:id", component: InstructionDetailComponent},
    { path: "detail", component: InstructionDetailComponent },
    { path: "", component: InstructionTableComponent},
    { path: "**", component: InstructionTableComponent}]

export const RoutingConfig = RouterModule.forRoot(routes);