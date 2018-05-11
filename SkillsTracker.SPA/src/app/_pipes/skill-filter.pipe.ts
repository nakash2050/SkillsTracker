import { Pipe, PipeTransform } from '@angular/core';
import { SkillModel } from '../_models/skill.model';

@Pipe({
  name: 'skillFilter'
})
export class SkillFilterPipe implements PipeTransform {

  transform(skills: SkillModel[], filter: string): SkillModel[] {    
    if (!skills || !filter) {
      return skills;
    }

    return skills.filter(category => this.applyFilter(category, filter));
  }

  applyFilter(skill: SkillModel, filter: string): boolean {
    return skill.skillName.toLowerCase().trim().indexOf(filter.toLowerCase().trim()) >= 0;
  }
}
