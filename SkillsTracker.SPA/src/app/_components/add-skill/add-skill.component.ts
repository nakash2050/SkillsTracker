import { Component, OnInit } from '@angular/core';
import { SkillService } from './../../_services/skill.service';
import { SkillModel } from '../../_models/skill.model';

@Component({
  selector: 'app-add-skill',
  templateUrl: './add-skill.component.html',
  styleUrls: ['./add-skill.component.css']
})
export class AddSkillComponent implements OnInit {

  skills: Array<SkillModel>;
  
  constructor(private skillService: SkillService) { }

  ngOnInit() {
    this.skillService.getSkills()
      .subscribe(response => this.skills = <Array<SkillModel>>response);
  }

}
