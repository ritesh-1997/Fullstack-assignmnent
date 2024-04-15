import { Component, OnInit } from '@angular/core';
import { HoldingsService } from '../services/holdings.service';
import { IUserHoldingsRequest } from '../Models/interfaces';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  ngOnInit() {
      this.getHoldings();
  }
  phoneNumber:string = '1111';
  userHoldingsRequest:IUserHoldingsRequest = {
    phoneNumber: '11111111111111111111',
    data: []
  };
 constructor(private holderService: HoldingsService,
  private router: Router
 ){

 }

 seeholdings(phoneNumber:string = '',strategyName:string=''){
  this.router.navigate(['/holding'], { queryParams: { phoneNumber: '1111', strategyName: 'Arbitrage Strategy' } })

 }
 getHoldings(){
  this.holderService.getHoldings({},this.phoneNumber).subscribe((response:any)=>{
    this.userHoldingsRequest = response;
    console.log(this.userHoldingsRequest);
  });
 }
}
