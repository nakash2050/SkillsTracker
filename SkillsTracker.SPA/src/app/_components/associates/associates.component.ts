import { Component, OnInit, Input } from '@angular/core';
import { AssociateDashboardModel } from '../../_models/associate.dashboard.model';

@Component({
  selector: 'app-associates',
  templateUrl: './associates.component.html',
  styleUrls: ['./associates.component.css']
})
export class AssociatesComponent implements OnInit {

  @Input('associates') associates: Array<AssociateDashboardModel>;
  nameSearch: any;
  empIdSearch: any;
  emailSearch: any;
  mobNoSearch: any;
  strongSkillsSearch: any;

  constructor() { }

  ngOnInit() {
    console.log(this.associates);
  }

}
