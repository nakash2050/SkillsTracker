import { Component, OnInit, ViewChild, ElementRef, Input } from '@angular/core';
import * as $ from 'jquery';
import { CandidatedDashboardModel } from './../../_models/candidated.dashboard.model';
import { TechnologyDashboardModel } from '../../_models/technology.dashboard.model';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  @Input('technology') technologyDashboard: TechnologyDashboardModel;
  @Input('candidates') candidatesDashboard: CandidatedDashboardModel;  
  
  context: CanvasRenderingContext2D;
  @ViewChild("html5") html5Canvas: ElementRef;
  @ViewChild("css3") css3Canvas: ElementRef;
  @ViewChild("java") javaCanvas: ElementRef;
  @ViewChild("csharp") csharpCanvas: ElementRef;
  @ViewChild("restful") restfulCanvas: ElementRef;
  @ViewChild("angular1") angular1Canvas: ElementRef;
  @ViewChild("angular2") angular2Canvas: ElementRef;
  @ViewChild("react") reactCanvas: ElementRef;  

  constructor() { }

  ngOnInit() {    
  }

  ngAfterViewInit(): void {
    const divWidth = ($('#divContainer').width());
    const safeLimit: number = 25;
    const font: string = '15px "Oswald", sans-serif';
    const fillStyle = 'black';
    const textAlign = 'center';

    let html5C = (<HTMLCanvasElement>this.html5Canvas.nativeElement);
    html5C.width = (divWidth * this.technologyDashboard.percentageOfHTML5Candidates) - safeLimit;
    this.context = (<HTMLCanvasElement>this.html5Canvas.nativeElement).getContext('2d');
    this.context.font = font;
    this.context.fillStyle = fillStyle;
    this.context.textAlign = textAlign;
    this.context.fillText('HTML5', html5C.width/2, html5C.height/2);

    let css3C = (<HTMLCanvasElement>this.css3Canvas.nativeElement);
    css3C.width = this.technologyDashboard.percentageOfCSS3Candidates != 0 ? (divWidth * this.technologyDashboard.percentageOfCSS3Candidates) - safeLimit : 0;
    this.context = (<HTMLCanvasElement>this.css3Canvas.nativeElement).getContext('2d');
    this.context.font = font;
    this.context.fillStyle = fillStyle;
    this.context.textAlign = textAlign;
    this.context.fillText('CSS3', css3C.width/2, css3C.height/2);

    let javaC = (<HTMLCanvasElement>this.javaCanvas.nativeElement);
    javaC.width = this.technologyDashboard.percentageOfJavaCandidates != 0 ? (divWidth * this.technologyDashboard.percentageOfJavaCandidates) - safeLimit : 0;
    this.context = (<HTMLCanvasElement>this.javaCanvas.nativeElement).getContext('2d');
    this.context.font = font;
    this.context.fillStyle = fillStyle;
    this.context.textAlign = textAlign;
    this.context.fillText('Java', javaC.width/2, javaC.height/2);

    let csharpC = (<HTMLCanvasElement>this.csharpCanvas.nativeElement);
    csharpC.width = this.technologyDashboard.percentageOfCSharpCandidates != 0 ? (divWidth * this.technologyDashboard.percentageOfCSharpCandidates) - safeLimit : 0;
    this.context = (<HTMLCanvasElement>this.csharpCanvas.nativeElement).getContext('2d');
    this.context.font = font;
    this.context.fillStyle = fillStyle;
    this.context.textAlign = textAlign;
    this.context.fillText('C#', csharpC.width/2, csharpC.height/2);

    let restfulC = (<HTMLCanvasElement>this.restfulCanvas.nativeElement);
    restfulC.width = this.technologyDashboard.percentageOfHTML5Candidates != 0 ? (divWidth * this.technologyDashboard.percentageOfHTML5Candidates) - safeLimit : 0;
    this.context = (<HTMLCanvasElement>this.restfulCanvas.nativeElement).getContext('2d');
    this.context.font = font;
    this.context.fillStyle = fillStyle;
    this.context.textAlign = textAlign;
    this.context.fillText('Restful', restfulC.width/2, restfulC.height/2);

    let angular1C = (<HTMLCanvasElement>this.angular1Canvas.nativeElement);
    angular1C.width = this.technologyDashboard.percentageOfAngular1Candidates != 0 ? (divWidth * this.technologyDashboard.percentageOfAngular1Candidates) - safeLimit : 0;
    this.context = (<HTMLCanvasElement>this.angular1Canvas.nativeElement).getContext('2d');
    this.context.font = font;
    this.context.fillStyle = fillStyle;
    this.context.textAlign = textAlign;
    this.context.fillText('Angular1', angular1C.width/2, angular1C.height/2);

    let angular2C = (<HTMLCanvasElement>this.angular2Canvas.nativeElement);
    angular2C.width = this.technologyDashboard.percentageOfAngular2Candidates != 0 ? (divWidth * this.technologyDashboard.percentageOfAngular2Candidates) - safeLimit : 0;
    this.context = (<HTMLCanvasElement>this.angular2Canvas.nativeElement).getContext('2d');
    this.context.font = font;
    this.context.fillStyle = fillStyle;
    this.context.textAlign = textAlign;
    this.context.fillText('Angular2', angular2C.width/2, angular2C.height/2);

    let reactC = (<HTMLCanvasElement>this.reactCanvas.nativeElement);
    reactC.width = this.technologyDashboard.percentageOfReactCandidates != 0 ? (divWidth * this.technologyDashboard.percentageOfReactCandidates) - safeLimit : 0;
    this.context = (<HTMLCanvasElement>this.reactCanvas.nativeElement).getContext('2d');
    this.context.font = font;
    this.context.fillStyle = fillStyle;
    this.context.textAlign = textAlign;
    this.context.fillText('React', reactC.width/2, reactC.height/2);
  }
}
