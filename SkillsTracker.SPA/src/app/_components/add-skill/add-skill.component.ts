import { Component, OnInit } from "@angular/core";
import { SkillService } from "./../../_services/skill.service";
import { SkillModel } from "../../_models/skill.model";
import * as _ from 'underscore';
import { Router } from "@angular/router";

@Component({
  selector: "app-add-skill",
  templateUrl: "./add-skill.component.html",
  styleUrls: ["./add-skill.component.css"]
})
export class AddSkillComponent implements OnInit {
  skills: Array<SkillModel>;
  skillName: string;
  searchSkill: string;

  constructor(
    private skillService: SkillService,
    private router: Router
  ) {}

  ngOnInit() {
    this.skillService
      .getSkills()
      .subscribe(response => {
        this.skills = <Array<SkillModel>>response;
      });
  }

  submit(form) {
    this.skillService.addSkill(form.value).subscribe(response => {
      form.reset();
      this.skills = <Array<SkillModel>>response;
    });
  }

  deleteSkill(skill: SkillModel) {
    this.skillService.deleteSkill(skill.skillId).subscribe(response => {
      if (response) {
        this.skills = _.without(this.skills, _.findWhere(this.skills, skill));
      }
    });
  }

  isEditOrSave(skill: SkillModel) {
    const isEdit = this.skills.filter(skl => skl.skillId == skill.skillId)[0].isEdit;
    this.skills.filter(skl => skl.skillId == skill.skillId)[0].isEdit = !isEdit;
    if (!isEdit) {
      document.getElementById("spn" + skill.skillId.toString()).focus();
    } else {
      this.skillService.updateSkill(skill).subscribe(resp => resp, error => {});
    }
  } 
}
