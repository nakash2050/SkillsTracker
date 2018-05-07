import { Injectable } from '@angular/core';
import { DataService } from '../_shared/data.service';
import { Http } from '@angular/http';
import { SkillModel } from '../_models/skill.model';

@Injectable()
export class SkillService extends DataService {
  private controllerName: string = "skill";

  constructor(http: Http) {
    super(http);
  }

  getSkills() {
    return this.get(this.controllerName);
  }

  addSkill(skill: any) {
    return this.post(this.controllerName, skill);
  }

  updateSkill(skill: SkillModel) {
    return this.update(this.controllerName + '/' + skill.skillId, skill);
  }

  deleteSkill(skillId) {
    return this.delete(this.controllerName + '/' + skillId);
  }
}
