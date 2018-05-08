import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { Http, HttpModule, BrowserXhr } from "@angular/http";
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { NgProgressModule, NgProgressBrowserXhr } from 'ngx-progressbar';

import { AppComponent } from './app.component';
import { AddSkillComponent } from './_components/add-skill/add-skill.component';

import { SkillService } from './_services/skill.service';
import { ContentEditableModelDirective } from './_directives/content-editable-model.directive';
import { HomeComponent } from './_components/home/home.component';
import { DashboardComponent } from './_components/dashboard/dashboard.component';
import { AddNewEmployeeSkillComponent } from './_components/add-new-employee-skill/add-new-employee-skill.component';
import { SliderComponent } from './_components/slider/slider.component';
import { AssociateService } from './_services/associate.service';
import { NumberOnlyDirective } from './_directives/number-only.directive';
import { SkillFilterPipe } from './_pipes/skill-filter.pipe';
import { AssociatesComponent } from './_components/associates/associates.component';
import { DashboardResolver } from './_resolvers/dashboard.resolver';
import { AssociateFilterPipe } from './_pipes/associate-filter.pipe';
import { AppErrorHandler } from './_shared/app-error-handler';
import { UpdateEmployeeSkillComponent } from './_components/update-employee-skill/update-employee-skill.component';
import { EmployeeResolver } from './_resolvers/employee.resolver';
import { SkillsResolver } from './_resolvers/skills.resolver.';
import { AlertifyService } from './_services/alertify.service';


const routes: Routes = [
  { path: "addskill", component: AddSkillComponent },
  { path: "home", component: HomeComponent, resolve: { dashboard: DashboardResolver } },
  { path: "newempskill", component: AddNewEmployeeSkillComponent },
  { path: "updateemp/:id", component: UpdateEmployeeSkillComponent, resolve: { employee: EmployeeResolver, skills: SkillsResolver } },
  { path: "addskill", component: AddSkillComponent },
  { path: "**", redirectTo: "home", pathMatch: "full" }
];

@NgModule({
  declarations: [
    AppComponent,
    AddSkillComponent,
    HomeComponent,
    DashboardComponent,
    AddNewEmployeeSkillComponent,
    SliderComponent,
    ContentEditableModelDirective,
    NumberOnlyDirective,
    AssociatesComponent,
    AssociateFilterPipe,
    SkillFilterPipe,
    UpdateEmployeeSkillComponent
  ],
  imports: [    
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes),
    HttpModule,
    ButtonsModule.forRoot(),
    ModalModule.forRoot(),
    TooltipModule.forRoot(),
    NgProgressModule
  ],
  providers: [
    SkillService,
    AssociateService,
    AlertifyService,
    DashboardResolver,
    EmployeeResolver,
    SkillsResolver,
    { provide: ErrorHandler, useClass: AppErrorHandler },
    { provide: BrowserXhr, useClass: NgProgressBrowserXhr }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
