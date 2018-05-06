import { Component, OnInit } from "@angular/core";
import { SkillService } from "../../_services/skill.service";
import { SkillModel } from "../../_models/skill.model";
import { Router } from "@angular/router";
import { AssociateService } from "./../../_services/associate.service";

@Component({
  selector: "app-add-new-employee-skill",
  templateUrl: "./add-new-employee-skill.component.html",
  styleUrls: ["./add-new-employee-skill.component.css"]
})
export class AddNewEmployeeSkillComponent implements OnInit {
  skills: Array<SkillModel>;
  status = "green";
  gender = "M";
  level = "L1";

  constructor(
    private skillService: SkillService,
    private router: Router,
    private associateService: AssociateService
  ) {}

  ngOnInit() {
    this.skillService.getSkills().subscribe(response => {
      this.skills = <Array<SkillModel>>response;
    });
  }

  submit(form) {
    console.log(form.value);

    const associateData: any = {
      associate: {
        associateId: form.value.associateId,
        name: form.value.name,
        email: form.value.email,
        mobile: form.value.mobile,
        remark: form.value.remark,
        strength: form.value.strength,
        weakness: form.value.weakness,
        gender: form.value.gender
      },
      skills: []
    };

    switch (form.value.level) {
      case "L1":
        associateData.associate.level1 = true;
        break;
      case "L2":
        associateData.associate.level2 = true;
        break;
      case "L3":
        associateData.associate.level3 = true;
        break;
    }

    switch (form.value.status) {
      case "green":
        associateData.associate.statusGreen = true;
        break;
      case "blue":
        associateData.associate.statusBlue = true;
        break;
      case "red":
        associateData.associate.statusRed = true;
        break;
    }

    let skills = form.value.skills;
    Object.keys(skills).forEach(key => {
      if (skills[key] != 0) {
        associateData.skills.push({ associateId: form.value.associateId, skillId: key, skillRating: skills[key] });
      }
    });

    console.log(associateData);

    this.associateService
      .addAssociateWithSkills(associateData)
      .subscribe(response => {
        console.log(response);
      });
  }

  reset(form) {
    for (let i = 0; i < this.skills.length; i++) {
      this.skills[i].skillRating = 0;
    }
  }

  cancel() {
    this.router.navigate(["/home"]);
  }
}
