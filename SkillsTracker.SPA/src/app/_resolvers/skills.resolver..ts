import { Resolve, ActivatedRouteSnapshot, Router } from "@angular/router";
import { Observable } from "rxjs/Rx";
import "rxjs/add/operator/catch";
import { Injectable } from "@angular/core";
import { SkillService } from "../_services/skill.service";

@Injectable()
export class SkillsResolver implements Resolve<any> {
  constructor(
    private skillsService: SkillService,
    private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<any> {
    return this.skillsService.getSkills().catch(error => {
      return Observable.of(null);
    });
  }
}
