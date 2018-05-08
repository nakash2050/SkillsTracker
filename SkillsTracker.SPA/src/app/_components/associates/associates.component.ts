import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';
import { AssociateDashboardModel } from '../../_models/associate.dashboard.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AssociateService } from '../../_services/associate.service';
import { AlertifyService } from './../../_services/alertify.service';
import * as _ from 'underscore';
import { AssociateWithSkillsModel } from '../../_models/associate.model';
import { AssociateSkillModel } from '../../_models/associate.skill.model';

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
  associateForDelete: AssociateDashboardModel;
  @ViewChild("template") modalTemplate: ElementRef;
  @ViewChild("associateTemplate") associateModalTemplate: ElementRef;
  modalRef: BsModalRef;
  associateData: AssociateWithSkillsModel;
  associateSkills: any;

  constructor(
    private modalService: BsModalService,
    private associateService: AssociateService,
    private alertifyService: AlertifyService
  ) { }

  ngOnInit() {    
  }

  openModal(template: any, associate: AssociateDashboardModel) {
    this.associateForDelete = associate;
    this.modalRef = this.modalService.show(template, { class: "modal-md" });
  }

  confirm(): void {
    this.associateService.deleteAssociate(this.associateForDelete.associateID).subscribe(response => {
      if(response){
        this.associates = _.without(this.associates, _.findWhere(this.associates, this.associateForDelete));
        this.modalRef.hide();
        this.alertifyService.success("Employee deleted successfully");
      }
    });
  }

  decline(): void {
    this.modalRef.hide();
  }

  openViewModal(template: any, associateId: number) {

    this.associateService.getAssociateWithSkills(associateId)
    .subscribe(response => {
      this.associateData = <AssociateWithSkillsModel>(response.associate);
      this.associateSkills = <Array<AssociateSkillModel>>(response.skills);
      this.associateSkills = _.map(<Array<AssociateSkillModel>>(response.skills), function(val, key){
        return val.skillName;
      }).join(', ');      
    });

    this.modalRef = this.modalService.show(template, { class: "modal-lg" });
  }
}
