import { Resolve, ActivatedRouteSnapshot, Router } from "@angular/router";
import { Observable } from "rxjs/Rx";
import "rxjs/add/operator/catch";
import { Injectable } from "@angular/core";
import { AssociateService } from "../_services/associate.service";

@Injectable()
export class DashboardResolver implements Resolve<any> {
  constructor(
    private associateService: AssociateService,
    private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<any> {
    return this.associateService.getDashboardData().catch(error => {
      return Observable.of(null);
    });
  }
}
