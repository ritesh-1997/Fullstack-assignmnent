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
  phoneNumber:string = '';
  ngOnInit() {
    this.phoneNumber = localStorage.getItem('Authorization')?.toString() ?? '';

    if(this.phoneNumber==''){
      this.router.navigate(['/login']);
    }
    else{
      this.router.navigate(['/home']);
      this.getHoldings();
    }
  }
  
  userHoldingsRequest:IUserHoldingsRequest = {
    phoneNumber: '11111111111111111111',
    data: []
  };
 constructor(private holderService: HoldingsService,
  private router: Router
 ){

 }

 seeholdings(phoneNumber:string = '',strategyName:string=''){
  this.router.navigate(['/holding'], { queryParams: { phoneNumber: phoneNumber, strategyName: strategyName } })

 }

 openTransact(){
  this.router.navigate(['/transact'])
 }

 getHoldings(){
  this.holderService.getHoldings({},this.phoneNumber).subscribe((response:any)=>{
    this.userHoldingsRequest = response;
    console.log(this.userHoldingsRequest);
  });
 }
}
