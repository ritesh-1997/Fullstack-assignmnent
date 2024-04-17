import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component, NgModule, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { InvestService } from '../services/invest.service';
import { IStrategyInvestment } from '../Models/interfaces';
import { OrderService } from '../services/order.service';

@Component({
  selector: 'app-investmentstatus',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './investmentstatus.component.html',
  styleUrl: './investmentstatus.component.css'
})
export class InvestmentstatusComponent implements OnInit  {
phoneNumber: string = '';
strategyBought: number = 0;
strategiesWithSucessfulPayment:IStrategyInvestment[] = []
constructor(private route: ActivatedRoute,
  private router: Router,
  private investService: InvestService,
  private orderService: OrderService,
  private changeDetector: ChangeDetectorRef
  ){

}
countOfSucessfulFund: number = 0;
isSuccess:boolean = false;
backToHome(){
  this.router.navigate(['/home']);
}

retryInvestement(){
  this.orderService.retryInvestement().subscribe((response:any)=>{
    if(response.success){
      this.isSuccess = true;
        this.strategyBought = response.count;
        this.strategiesWithSucessfulPayment = response.data;
        this.countOfSucessfulFund = response.data.filter((x: { success: boolean; })=>x.success === true).length;
    }
    this.changeDetector.detectChanges();
  });
}
ngOnInit() {
  this.phoneNumber = localStorage.getItem('Authorization')?.toString() || '';

    if(this.phoneNumber==''){
      this.router.navigate(['/login']);
    }
    this.buyStrategy();
  // this.route.queryParams.subscribe((param: any) => {
  //   console.log(param);
  //   if(param.success){
  //     this.isSuccess = true;
  //   }
  // })
}


  buyStrategy() {
    this.investService.buyfunds().subscribe((response:any)=>{
      if(response.success ){
        this.isSuccess = true;
        this.strategyBought = response.count;
        this.strategiesWithSucessfulPayment = response.data;
        this.countOfSucessfulFund = response.data.filter((x: { success: boolean; })=>x.success === true).length;
      }
      this.changeDetector.detectChanges();

    });
  }
}
