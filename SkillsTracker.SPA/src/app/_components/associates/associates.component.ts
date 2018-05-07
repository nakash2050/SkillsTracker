import { Component, OnInit, Input } from '@angular/core';
import { AssociateDashboardModel } from '../../_models/associate.dashboard.model';

@Component({
  selector: 'app-associates',
  templateUrl: './associates.component.html',
  styleUrls: ['./associates.component.css']
})
export class AssociatesComponent implements OnInit {

  @Input('associates') associates: Array<AssociateDashboardModel>;

  constructor() { }

  ngOnInit() {
    console.log(this.associates);
  }

}
