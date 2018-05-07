import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { Http, HttpModule } from "@angular/http";
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TooltipModule } from 'ngx-bootstrap/tooltip';

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


const routes: Routes = [
  { path: "addskill", component: AddSkillComponent },
  { path: "home", component: HomeComponent, resolve: { dashboard: DashboardResolver } },
  { path: "newempskill", component: AddNewEmployeeSkillComponent },
  { path: "**", redirectTo: "addskill", pathMatch: "full" }
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
    SkillFilterPipe
  ],
  imports: [  
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes),
    HttpModule,
    ButtonsModule.forRoot(),
    ModalModule.forRoot(),
    TooltipModule.forRoot()
  ],
  providers: [
    SkillService,
    AssociateService,
    DashboardResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
