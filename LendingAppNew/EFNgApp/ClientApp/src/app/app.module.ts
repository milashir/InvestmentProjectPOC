import { NgModule } from '@angular/core';
import { InvestmentService } from './services/investmentservice.service'
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AddInvestmentComponent } from './components/add-investment/add-investment.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
 

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AddInvestmentComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    CommonModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule, 
    RouterModule.forRoot([
        { path: '', component: HomeComponent, pathMatch: 'full' },
        { path: 'home', component: HomeComponent },  
      { path: 'add-investment', component: AddInvestmentComponent },
      { path: 'investment/add/:id', component: AddInvestmentComponent },
        { path: '**', redirectTo: 'home' }  
    ])
  ],
  providers: [InvestmentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
