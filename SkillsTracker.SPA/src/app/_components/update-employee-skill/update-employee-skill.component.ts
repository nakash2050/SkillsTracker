import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { AssociateWithSkillsModel } from "../../_models/associate.model";
import { SkillModel } from "../../_models/skill.model";
import * as _ from "underscore";
import { SkillService } from "./../../_services/skill.service";
import { AssociateService } from "../../_services/associate.service";
import { AlertifyService } from './../../_services/alertify.service';

@Component({
  selector: "app-update-employee-skill",
  templateUrl: "./update-employee-skill.component.html",
  styleUrls: ["./update-employee-skill.component.css"]
})
export class UpdateEmployeeSkillComponent implements OnInit {
  empData: any;
  skills: Array<SkillModel>;
  skillSearch: string;
  newSkillName: string;
  status = "";
  gender = "";
  level = "";
  imageUrl;
  fileName: string;
  selectedFile: File;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private skillService: SkillService,
    private associateService: AssociateService,
    private alertifyService: AlertifyService
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.empData = data["employee"];
      this.skills = data["skills"];

      if (this.empData.associate) {
        this.imageUrl = this.empData.associate.picture;

        if (this.empData.associate.level1) {
          this.level = "L1";
        } else if (this.empData.associate.level2) {
          this.level = "L2";
        } else {
          this.level = "L3";
        }

        if (this.empData.associate.statusGreen) {
          this.status = "green";
        } else if (this.empData.associate.statusBlue) {
          this.status = "blue";
        } else {
          this.status = "red";
        }
      }
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
    switch (this.level) {
      case "L1":
        this.empData.associate.level1 = true;
        this.empData.associate.level2 = false;
        this.empData.associate.level3 = false;
        break;
      case "L2":
        this.empData.associate.level2 = true;
        this.empData.associate.level1 = false;
        this.empData.associate.level3 = false;
        break;
      case "L3":
        this.empData.associate.level3 = true;
        this.empData.associate.level1 = false;
        this.empData.associate.level2 = false;
        break;
    }

    switch (this.status) {
      case "green":
        this.empData.associate.statusGreen = true
        this.empData.associate.statusBlue = false;
        this.empData.associate.statusRed = false;
        break;
      case "blue":
        this.empData.associate.statusBlue = true;
        this.empData.associate.statusGreen = false;
        this.empData.associate.statusRed = false;
        break;
      case "red":
        this.empData.associate.statusRed = true;
        this.empData.associate.statusBlue = false;
        this.empData.associate.statusGreen = false;
        break;
    }

    this.empData.skills = [];
    Object.keys(this.skills).forEach(key => {
      if (this.skills[key].skillRating != 0) {
        this.empData.skills.push({
          associateId: this.empData.associate.associateId,
          skillId: this.skills[key].skillId,
          skillRating: this.skills[key].skillRating
        });
      }
    });

  
    let formData: FormData = new FormData();

    if (this.selectedFile != null) {
      formData.append("uploadFile", this.selectedFile, this.selectedFile.name);
    }
    formData.append("formValue", JSON.stringify(this.empData));

    this.associateService.updateAssociateWithSkillsAndImage(formData)
    .subscribe(response => {
      if(response.status) {
        this.router.navigate(['/home']);
      } else {
        this.alertifyService.error("Employee data update unsuccessfull");
      }
    });
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

  fileChange(event) {
    this.selectedFile = <File>event.target.files[0];
    this.fileName = this.selectedFile.name;
    var reader = new FileReader();

    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
    };

    reader.readAsDataURL(this.selectedFile);
  }
}
