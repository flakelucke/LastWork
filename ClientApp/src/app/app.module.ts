import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule} from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ModelModule } from "./models/model.module";
import { AppComponent } from './app.component';
import { HttpModule } from '@angular/http';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { InstructionTableComponent } from './structure/instruction-table/instruction-table.component';
import { InstructionDetailComponent } from './structure/instruction-detail/instruction-detail.component';
import { RoutingConfig } from './app.routing';
import { AdminModule } from "./admin/admin.module";
import { PaginationComponent } from "./structure/pagination/pagination.component";
import { AuthModule } from "./auth/auth.module";
import { UserDetailComponent } from './structure/user-detail/user-detail.component';
import { FooterComponent } from './structure/footer/footer.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    InstructionTableComponent,
    InstructionDetailComponent,
    PaginationComponent,
    UserDetailComponent,
    FooterComponent
    ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ModelModule,
    HttpModule,
    RoutingConfig,
    AdminModule,
    AuthModule,
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: [UserDetailComponent]
})
export class AppModule { }
