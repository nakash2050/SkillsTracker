import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AssociateDashboardModel } from './../../_models/associate.dashboard.model';
import { CandidatedDashboardModel } from './../../_models/candidated.dashboard.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  dashboardData: any;
  associatesDashboard: Array<AssociateDashboardModel>;
  candidatesDashboard: CandidatedDashboardModel;

  constructor(
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.dashboardData = data["dashboard"];

      if(this.dashboardData != null){
        this.associatesDashboard = <Array<AssociateDashboardModel>>(this.dashboardData.associates);
        this.candidatesDashboard = <CandidatedDashboardModel>(this.dashboardData.candidates);
      }
    });
  }

}
