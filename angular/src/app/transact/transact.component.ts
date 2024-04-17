import { ChangeDetectorRef, Component, ElementRef, NgModule, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IFunds, IInvestmentStrategy, IStrategyInvestment } from '../Models/interfaces';
import { StrategyService } from '../services/strategy.service';
import { InvestService } from '../services/invest.service';
import { NgSelectModule } from '@ng-select/ng-select';
import { Router } from '@angular/router';

@Component({
  selector: 'app-transact',
  standalone: true,
  imports: [FormsModule,CommonModule,NgSelectModule],
  templateUrl: './transact.component.html',
  styleUrl: './transact.component.css'
})
export class TransactComponent implements OnInit{
  /**
   *
   */
  constructor( private strategyService: StrategyService,
    private investService:InvestService,
    private router:Router,
    private changeDetector: ChangeDetectorRef) {
  }
  selectedStrategyValue:any=0;
  stratagies:any[] =[];
  ngOnInit() {
    var phoneNumber = localStorage.getItem('Authorization');
    if(phoneNumber == null ||phoneNumber.length == 0){
      this.router.navigate(['/login']);
    }
    this.getInvestmentStrategies();
  }
  selectedFund = 'Arbitrage Strategy';
  strategyInvestment: IStrategyInvestment = {
    name:'',
    amount: 100,
    description:'',

    funds: [],
  } ;
  investmentStrategies: IInvestmentStrategy[]=[];
  getSelectedStrategy(selectedFund: string){
    const strategy  = this.investmentStrategies.find(strategy => strategy.name === selectedFund);
    if(strategy !=null){
      this.strategyInvestment.name = strategy.name;
      this.strategyInvestment.amount = 100;
      const funds: IFunds[] = [];
      for (let i = 0; i < strategy.funds.length; i++) {
        const currentFund = strategy.funds[i];
        const fund:IFunds = {
          name:currentFund.name,
          percentage:currentFund.percentage/100,
          value : currentFund.percentage/100*this.strategyInvestment.amount,

        };
        funds.push(fund);
      }
      this.strategyInvestment.funds = funds;
    }
    
  }
  getInvestmentStrategies(){

    this.strategyService.investmentStrategies().subscribe(
      (response:any)=>{
        this.investmentStrategies = response;
        
        this.investmentStrategies.map((x:any,index:number)=>
                                    this.stratagies.push({id:index,value:x.name}));
        console.log(this.stratagies);
        this.getSelectedStrategy(this.selectedFund);
        this.changeDetector.detectChanges();
      })
  }

  changeStrategy(event: any){
    if(event &&event.id){
      console.log(event.value);
      this.getSelectedStrategy(event.value);
    }
  }
  
  invest(){
    this.investService.invest(this.strategyInvestment).subscribe((response:any)=>{
      
      if(response.success==true||response.success==false){
        this.navigateToExternalUrl(response.paymentLink);
      }
        // this.router.navigate(['/transaction'],{ queryParams: { isSuccess: response.success, paymentLink: response.paymentLink } });
      this.changeDetector.detectChanges();
    });
  }

  navigateToExternalUrl(url: string) {
    window.location.href = url; // Redirects the current tab
}
  allowedChars = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.'];

  @ViewChild('numberInputRef')
  numberInputRef!: ElementRef<HTMLInputElement>;

  onKeyPress(event: KeyboardEvent) {
    const char = String.fromCharCode(event.charCode);
    if (!this.allowedChars.includes(char) && event.charCode !== 0) {
      event.preventDefault();
      this.numberInputRef.nativeElement.classList.add('invalid');
    } else {
      this.numberInputRef.nativeElement.classList.remove('invalid');
    }
  }
}
