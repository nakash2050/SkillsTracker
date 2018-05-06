import {
  Component,
  OnInit,
  TemplateRef,
  ViewChild,
  ElementRef
} from "@angular/core";
import { SkillService } from "../../_services/skill.service";
import { SkillModel } from "../../_models/skill.model";
import { Router } from "@angular/router";
import { AssociateService } from "./../../_services/associate.service";
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
import { Form, FormControl, FormGroup, AbstractControl } from "@angular/forms";
import { BadRequestError } from "./../../_shared/bad-request-error";
import { Observable } from "rxjs/Observable";
import { Http, RequestOptions } from "@angular/http";

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
  dataSaved: boolean = false;
  modalRef: BsModalRef;
  @ViewChild("template") modalTemplate: ElementRef;
  name = "";
  associateId: any;
  email = "";
  mobile = "";
  remark = "";
  strength = "";
  weakness = "";
  form: FormGroup;
  associateExistsError: string = null;
  imageUrl;  

  constructor(
    private skillService: SkillService,
    private router: Router,
    private associateService: AssociateService,
    private modalService: BsModalService,
    private http: Http
  ) {}

  ngOnInit() {
    this.skillService.getSkills().subscribe(response => {
      this.skills = <Array<SkillModel>>response;
    });
  }

  selectedFile: File;

  submit(form) {
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
        associateData.skills.push({
          associateId: form.value.associateId,
          skillId: key,
          skillRating: skills[key]
        });
      }
    });

    let formData: FormData = new FormData();

    if (this.selectedFile != null) {
      formData.append("uploadFile", this.selectedFile, this.selectedFile.name);
    }
    formData.append("formValue", JSON.stringify(associateData));

    this.associateService.addAssociateWithSkillsAndImage(formData).subscribe(
      response => {
        this.dataSaved = response.status;
        this.associateExistsError = null;
        this.modalRef = this.modalService.show(this.modalTemplate);
        this.reset(form);
      },
      error => {
        if (error instanceof BadRequestError) {
          let err = <BadRequestError>error;
          this.associateExistsError = JSON.parse(
            err.originalError._body
          ).message;
          this.modalRef = this.modalService.show(this.modalTemplate);
        }
      }
    );
  }

  reset(form: FormGroup) {
    this.name = "";
    this.associateId = "";
    this.email = "";
    this.mobile = "";
    this.remark = "";
    this.strength = "";
    this.weakness = "";
    this.status = "green";
    this.gender = "M";
    this.level = "L1";
    this.imageUrl = null;    

    Object.keys(form.controls).forEach(main => {
      let control = form.controls[main];
      control.markAsUntouched();
    });

    for (let i = 0; i < this.skills.length; i++) {
      this.skills[i].skillRating = 0;
    }
  }

  cancel() {
    this.router.navigate(["/home"]);
  }

  fileName: string;

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
