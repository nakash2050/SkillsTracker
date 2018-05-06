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

  addAssociateWithSkills(associate: AssociateWithSkillsModel) {
    return this.post(this.controllerName + '/withskills', associate);
  }

  updateAssociateWithSkills(associate: AssociateWithSkillsModel) {
    return this.update(this.controllerName + '/' + associate.associateId, associate);
  }

  deleteAssociate(associateId) {
    return this.delete(this.controllerName + '/' + associateId);
  }
}
