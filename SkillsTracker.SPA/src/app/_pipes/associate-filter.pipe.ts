import { Pipe, PipeTransform } from '@angular/core';
import { AssociateDashboardModel } from '../_models/associate.dashboard.model';

@Pipe({
  name: 'associateFilter'
})
export class AssociateFilterPipe implements PipeTransform {

  transform(associates: AssociateDashboardModel[], nameSearch: string, empIdSearch: string, emailSearch: string, mobNoSearch: string, strongSkillsSearch: string): AssociateDashboardModel[] {
    if (associates && associates.length) {
      return associates.filter(item => {
          if (nameSearch && item.name.toLowerCase().indexOf(nameSearch.toLowerCase()) === -1){
              return false;
          }
          if (empIdSearch && item.associateID.toLowerCase().indexOf(empIdSearch.toLowerCase()) === -1){
            return false;
          }
          if (emailSearch && item.email.toLowerCase().indexOf(emailSearch.toLowerCase()) === -1){
              return false;
          }
          if (mobNoSearch && item.mobile.toLowerCase().indexOf(mobNoSearch.toLowerCase()) === -1){
              return false;
          }
          if (strongSkillsSearch && item.skills.toLowerCase().indexOf(strongSkillsSearch.toLowerCase()) === -1){
            return false;
          }
          
          return true;
     })
  }
  else {
      return associates;
    }
  }

}
