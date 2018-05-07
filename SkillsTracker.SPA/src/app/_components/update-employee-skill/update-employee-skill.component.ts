import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { AssociateWithSkillsModel } from "../../_models/associate.model";
import { SkillModel } from "../../_models/skill.model";
import * as _ from "underscore";
import { SkillService } from "./../../_services/skill.service";

@Component({
  selector: "app-update-employee-skill",
  templateUrl: "./update-employee-skill.component.html",
  styleUrls: ["./update-employee-skill.component.css"]
})
export class UpdateEmployeeSkillComponent implements OnInit {
  empData: AssociateWithSkillsModel;
  skills: Array<SkillModel>;
  skillSearch: string;
  newSkillName: string;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private skillService: SkillService
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.empData = <AssociateWithSkillsModel>data["employee"];
      this.skills = data["skills"];
    });

    if (this.empData.skills && this.empData.skills.length > 0) {
      if (this.skills && this.skills.length > 0) {
        for (let empSkill of this.empData.skills) {
          _.findWhere(this.skills, { skillId: empSkill.skillId }).skillRating =
            empSkill.skillRating;
        }
      }
    }
  }

  update() {
    console.log(this.skills);
  }

  addSkill(newSkillName) {
    const skill = { skillName: newSkillName };
    this.skillService.addSkill(skill).subscribe(response => {
      let addedSkills = <Array<SkillModel>>response;

      if (addedSkills.length > this.skills.length) {
        this.skills.unshift(addedSkills[0]);
        this.newSkillName = "";
      }
    });
  }
}
