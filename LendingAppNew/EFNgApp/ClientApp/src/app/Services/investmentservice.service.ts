import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw'; 

@Injectable()
export class InvestmentService {
  myAppUrl: string = "";

  constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }  

  getProjects() {
    return this._http.get(this.myAppUrl + 'api/Investment/Index')
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  getProjectById(id: number) {
    return this._http.get(this.myAppUrl + "api/Project/Details/" + id)
      .map((response: Response) => response.json())
      .catch(this.errorHandler)
  }

  addInvestment(investment) {
    return this._http.post(this.myAppUrl + 'api/Investment/Add', investment)
      .map((response: Response) => response.json())
      .catch(this.errorHandler)
  }  

  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }   

}
