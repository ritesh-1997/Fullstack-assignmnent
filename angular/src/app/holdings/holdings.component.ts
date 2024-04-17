import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { HoldingsService } from '../services/holdings.service';
import { IHoldingsResponse, IUserHoldingsRequest } from '../Models/interfaces';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-holdings',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './holdings.component.html',
  styleUrl: './holdings.component.css'
})
export class HoldingsComponent implements OnInit {
  userHolding: IHoldingsResponse = {
    strategyName:'',
    investmentAmount:0,
    investmentMarketValue:0,
    holdingDetails:[]
  }


  constructor(private holdingsService:HoldingsService,
    private route: ActivatedRoute,
    private router: Router,
    private changeDetector: ChangeDetectorRef
  ){}
  
  strategyName:string = '';
  phoneNumber:string = '';
  ngOnInit(){
    this.phoneNumber = localStorage.getItem('Authorization')?.toString() || '';

    if(this.phoneNumber==''){
      this.router.navigate(['/login']);
    }
    this.route.queryParams.subscribe((param: any) => {
      console.log(param);
      this.strategyName = param.strategyName,
      this.phoneNumber = param.phoneNumber

    })
    this.getHolding(this.phoneNumber, this.strategyName);
  }

  backToHome(){
    this.router.navigate(['/home']);
  }
  getHolding(phoneNumber: string, strategyName: string){
    const payload = {"phoneNumber":phoneNumber, "strategyName":strategyName}
    this.holdingsService.getHolding(payload).subscribe((response:any)=>{
      this.userHolding = response;
      this.changeDetector.detectChanges()
      console.log(this.userHolding);
    })
  }
}
