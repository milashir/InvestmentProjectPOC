import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { InvestmentService } from '../../services/investmentservice.service';

@Component({
  selector: 'app-add-investment',
  templateUrl: './add-investment.component.html',
  styleUrls: ['./add-investment.component.css']
})

export class AddInvestmentComponent implements OnInit {
  investmentForm: FormGroup;
  title: string = "Create";
  projectId: number;
  errorMessage: any;
  cityList: Array<any> = [];

  //public investment: Investment;

  constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
    private _investmentService: InvestmentService, private _router: Router) {
    if (this._avRoute.snapshot.params["id"]) {
      this.projectId = this._avRoute.snapshot.params["id"];
    }

    this.investmentForm = this._fb.group({
      id: 0,
      name: ['this.investmentForm.get("name").value'],
      amount: ['', [Validators.required, Validators.min(100), Validators.max(10000)]]
    })
  }

  ngOnInit() {   

    if (this.projectId > 0) {
      this.title = "Invest in this Project";
      this._investmentService.getProjectById(this.projectId)
        .subscribe(resp => this.investmentForm.setValue(resp)
          , error => this.errorMessage = error);
    }

  }

  save() {   
    if (!this.investmentForm.valid) {
      return;
    }

    if (this.projectId > 0) {
      this._investmentService.addInvestment(this.investmentForm.value)
        .subscribe((data) => {
          this._router.navigate(['/home']);
        }, error => this.errorMessage = error)
    }
  }

cancel() {
  window.history.back();
}
  
  get id() { return this.investmentForm.get('id'); }
  get name() { return this.investmentForm.get('name'); }
  get amount() { return this.investmentForm.get('amount'); }
}


