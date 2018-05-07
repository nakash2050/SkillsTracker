import { Component, OnInit, ViewChild, ElementRef, Input } from '@angular/core';
import * as $ from 'jquery';
import { CandidatedDashboardModel } from './../../_models/candidated.dashboard.model';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  @Input('candidates') candidatesDashboard: CandidatedDashboardModel;
  
  context: CanvasRenderingContext2D;
  @ViewChild("html5") html5Canvas: ElementRef;
  @ViewChild("css3") css3Canvas: ElementRef;
  @ViewChild("java") javaCanvas: ElementRef;
  @ViewChild("spring") springCanvas: ElementRef;
  @ViewChild("restful") restfulCanvas: ElementRef;
  @ViewChild("angular1") angular1Canvas: ElementRef;
  @ViewChild("angular2") angular2Canvas: ElementRef;
  @ViewChild("react") reactCanvas: ElementRef;  

  constructor() { }

  ngOnInit() {
    console.log(this.candidatesDashboard);
  }

  ngAfterViewInit(): void {
    let html5C = (<HTMLCanvasElement>this.html5Canvas.nativeElement);
    html5C.width = 106;
    this.context = (<HTMLCanvasElement>this.html5Canvas.nativeElement).getContext('2d');
    this.context.font = '15px "Oswald", sans-serif';
    this.context.fillStyle = "black";
    this.context.textAlign = "center";
    this.context.fillText('HTML5', html5C.width/2, html5C.height/2);

    let css3C = (<HTMLCanvasElement>this.css3Canvas.nativeElement);
    css3C.width = 353;
    this.context = (<HTMLCanvasElement>this.css3Canvas.nativeElement).getContext('2d');
    this.context.font = '15px "Oswald", sans-serif';
    this.context.fillStyle = 'black';
    this.context.textAlign = 'center';
    this.context.fillText('CSS3', css3C.width/2, css3C.height/2);

    let javaC = (<HTMLCanvasElement>this.javaCanvas.nativeElement);
    javaC.width = 470;
    this.context = (<HTMLCanvasElement>this.javaCanvas.nativeElement).getContext('2d');
    this.context.font = '15px "Oswald", sans-serif';
    this.context.fillStyle = 'black';
    this.context.textAlign = 'center';
    this.context.fillText('Java', javaC.width/2, javaC.height/2);

    let springC = (<HTMLCanvasElement>this.springCanvas.nativeElement);
    springC.width = 235;
    this.context = (<HTMLCanvasElement>this.springCanvas.nativeElement).getContext('2d');
    this.context.font = '15px "Oswald", sans-serif';
    this.context.fillStyle = 'black';
    this.context.textAlign = 'center';
    this.context.fillText('Spring', springC.width/2, springC.height/2);

    let restfulC = (<HTMLCanvasElement>this.restfulCanvas.nativeElement);
    restfulC.width = 0;
    this.context = (<HTMLCanvasElement>this.restfulCanvas.nativeElement).getContext('2d');
    this.context.font = '15px "Oswald", sans-serif';
    this.context.fillStyle = 'black';
    this.context.textAlign = 'center';
    this.context.fillText('Restful', restfulC.width/2, restfulC.height/2);

    let angular1C = (<HTMLCanvasElement>this.angular1Canvas.nativeElement);
    angular1C.width = 0;
    this.context = (<HTMLCanvasElement>this.angular1Canvas.nativeElement).getContext('2d');
    this.context.font = '15px "Oswald", sans-serif';
    this.context.fillStyle = 'black';
    this.context.textAlign = 'center';
    this.context.fillText('Angular1', angular1C.width/2, angular1C.height/2);

    let angular2C = (<HTMLCanvasElement>this.angular2Canvas.nativeElement);
    angular2C.width = 235;
    this.context = (<HTMLCanvasElement>this.angular2Canvas.nativeElement).getContext('2d');
    this.context.font = '15px "Oswald", sans-serif';
    this.context.fillStyle = 'black';
    this.context.textAlign = 'center';
    this.context.fillText('Angular2', angular2C.width/2, angular2C.height/2);

    let reactC = (<HTMLCanvasElement>this.reactCanvas.nativeElement);
    reactC.width = 0;
    this.context = (<HTMLCanvasElement>this.reactCanvas.nativeElement).getContext('2d');
    this.context.font = '15px "Oswald", sans-serif';
    this.context.fillStyle = 'black';
    this.context.textAlign = 'center';
    this.context.fillText('React', reactC.width/2, reactC.height/2);

    console.log($('#divContainer').width());
  }
}
