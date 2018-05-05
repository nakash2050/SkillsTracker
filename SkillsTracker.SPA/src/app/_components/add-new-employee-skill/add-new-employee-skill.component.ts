import { Component, OnInit } from "@angular/core";
import { SkillService } from "../../_services/skill.service";
import { SkillModel } from "../../_models/skill.model";
import { Router } from "@angular/router";

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
