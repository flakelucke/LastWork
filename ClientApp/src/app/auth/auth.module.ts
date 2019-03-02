import { AuthenticationService } from "./authentication.service";
import { AuthenticationComponent } from "./authentication/authentication.component";
import { AuthenticationGuard } from "./authentication.guard";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { RegisterComponent } from "./register/register.component";
import { RegistrationService } from "./registration.service";
import { RoleGuard } from "./role.guard";

@NgModule({
    imports: [RouterModule, FormsModule, BrowserModule],
    declarations: [AuthenticationComponent,RegisterComponent],
    providers: [AuthenticationService, AuthenticationGuard,RegistrationService,RoleGuard],
    exports: [AuthenticationComponent]
})
export class AuthModule { }