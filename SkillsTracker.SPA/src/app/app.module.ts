import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { Http, HttpModule } from "@angular/http";

import { AppComponent } from './app.component';
import { AddSkillComponent } from './_components/add-skill/add-skill.component';

import { SkillService } from './_services/skill.service';
import { ContentEditableModelDirective } from './_directives/content-editable-model.directive';
import { HomeComponent } from './_components/home/home.component';
import { DashboardComponent } from './_components/dashboard/dashboard.component';

const routes: Routes = [
  { path: "addskill", component: AddSkillComponent },
  { path: "home", component: HomeComponent },
  { path: "**", redirectTo: "addskill", pathMatch: "full" }
];

@NgModule({
  declarations: [
    AppComponent,
    AddSkillComponent,
    ContentEditableModelDirective,
    HomeComponent,
    DashboardComponent
  ],
  imports: [  
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes),
    HttpModule
  ],
  providers: [
    SkillService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
