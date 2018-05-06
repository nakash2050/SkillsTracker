import { Pipe, PipeTransform } from '@angular/core';
import { SkillModel } from '../_models/skill.model';

@Pipe({
  name: 'skillFilter'
})
export class SkillFilterPipe implements PipeTransform {

  transform(categories: SkillModel[], filter: string): SkillModel[] {
    if (!categories || !filter) {
      return categories;
    }

    return categories.filter(category => this.applyFilter(category, filter));
  }

  applyFilter(skill: SkillModel, filter: string): boolean {
    return skill.skillName.toLowerCase().trim().indexOf(filter) >= 0;
  }
}
