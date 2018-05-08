import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';
import { AssociateDashboardModel } from '../../_models/associate.dashboard.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AssociateService } from '../../_services/associate.service';
import { AlertifyService } from './../../_services/alertify.service';
import * as _ from 'underscore';

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
  modalRef: BsModalRef;

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
        //this.associates = _.without(this.associates, _.findWhere(this.associates, this.associateForDelete));
        this.modalRef.hide();
        this.alertifyService.success("Employee deleted successfully");
        window.location.reload();
      }
    });
  }

  decline(): void {
    this.modalRef.hide();
  }
}
