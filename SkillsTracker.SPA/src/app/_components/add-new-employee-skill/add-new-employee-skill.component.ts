import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-new-employee-skill',
  templateUrl: './add-new-employee-skill.component.html',
  styleUrls: ['./add-new-employee-skill.component.css']
})
export class AddNewEmployeeSkillComponent implements OnInit {

  constructor() { }

  radioModel = 'green';
  genderModel = 'male';

  ngOnInit() {
  }

}
