import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { Http, HttpModule } from "@angular/http";
import { ButtonsModule } from 'ngx-bootstrap/buttons';


import { AppComponent } from './app.component';
import { AddSkillComponent } from './_components/add-skill/add-skill.component';

import { SkillService } from './_services/skill.service';
import { ContentEditableModelDirective } from './_directives/content-editable-model.directive';
import { HomeComponent } from './_components/home/home.component';
import { DashboardComponent } from './_components/dashboard/dashboard.component';
import { AddNewEmployeeSkillComponent } from './_components/add-new-employee-skill/add-new-employee-skill.component';

const routes: Routes = [
  { path: "addskill", component: AddSkillComponent },
  { path: "home", component: HomeComponent },
  { path: "newempskill", component: AddNewEmployeeSkillComponent },
  { path: "**", redirectTo: "addskill", pathMatch: "full" }
];

@NgModule({
  declarations: [
    AppComponent,
    AddSkillComponent,
    ContentEditableModelDirective,
    HomeComponent,
    DashboardComponent,
    AddNewEmployeeSkillComponent
  ],
  imports: [  
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes),
    HttpModule,
    ButtonsModule.forRoot()
  ],
  providers: [
    SkillService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
