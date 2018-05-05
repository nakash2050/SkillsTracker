import { Component, OnInit } from "@angular/core";
import { SkillService } from "../../_services/skill.service";
import { SkillModel } from "../../_models/skill.model";
import { Router } from "@angular/router";
import { AssociateModel } from "./../../_models/associate.model";

@Component({
  selector: "app-add-new-employee-skill",
  templateUrl: "./add-new-employee-skill.component.html",
  styleUrls: ["./add-new-employee-skill.component.css"]
})
export class AddNewEmployeeSkillComponent implements OnInit {
  skills: Array<SkillModel>;

  constructor(private skillService: SkillService, private router: Router) {}

  status = "green";
  gender = "male";
  level = "L1";

  ngOnInit() {
    this.skillService.getSkills().subscribe(response => {
      this.skills = <Array<SkillModel>>response;
    });
  }

  submit(form) {
    console.log(form.value);

    const associateData: any = {
      associateId: form.value.associateId,
      name: form.value.name,
      email: form.value.email,
      mobile: form.value.mobile,
      remark: form.value.remark,
      strength: form.value.strength,
      weakness: form.value.weakness,
      skills: []
    };

    switch (form.value.level) {
      case "L1":
        associateData.level1 = true;
        break;
      case "L2":
        associateData.level2 = true;
        break;
      case "L3":
        associateData.level3 = true;
        break;
    }

    switch (form.value.status) {
      case "green":
        associateData.statusGreen = true;
        break;
      case "blue":
        associateData.statusBlue = true;
        break;
      case "red":
        associateData.statusRed = true;
        break;
    }

    let skills = form.value.skills;
    Object.keys(skills).forEach(key => {
      if (skills[key] != 0) {
        associateData.skills.push({ skillId: key, skillRating: skills[key] });
      }
    });

    console.log(associateData);
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
