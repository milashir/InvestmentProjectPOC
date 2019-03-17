import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { InvestmentService } from '../services/investmentservice.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public projectList: ProjectData[];

  constructor(public http: Http, private _router: Router, private _investmentService: InvestmentService) {
    this.getProjects();
  }

  getProjects() {
    this._investmentService.getProjects().subscribe(
      data => this.projectList = data
    )
  }
}

interface ProjectData {
  id: number;
  projectName: string;
  location: string;
  price: number;
  status: number;
}
