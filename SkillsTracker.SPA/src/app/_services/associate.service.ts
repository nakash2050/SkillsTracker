import { Injectable } from '@angular/core';
import { DataService } from '../_shared/data.service';
import { Http } from '@angular/http';
import { SkillModel } from '../_models/skill.model';
import { AssociateWithSkillsModel } from '../_models/associate.model';

@Injectable()
export class AssociateService extends DataService {
  private controllerName: string = "associate";

  constructor(http: Http) {
    super(http);
  }

  getAllAssociates() {
    return this.get(this.controllerName);
  }

  addAssociateWithSkillsAndImage(formData: FormData) {
    return this.post(this.controllerName + '/withSkills', formData);
  }

  updateAssociate(associate: AssociateWithSkillsModel) {
    return this.update(this.controllerName + '/' + associate.associateId, associate);
  }

  updateAssociateWithSkillsAndImage(formData: FormData) {
    return this.update(this.controllerName + '/withSkills', formData);
  }

  deleteAssociate(associateId) {
    return this.delete(this.controllerName + '/' + associateId);
  }

  getDashboardData() {
    return this.get(this.controllerName + '/dashboard');
  }

  getAssociateWithSkills(empId){
    return this.get(this.controllerName + '/withSkills/' + empId);
  }
}
