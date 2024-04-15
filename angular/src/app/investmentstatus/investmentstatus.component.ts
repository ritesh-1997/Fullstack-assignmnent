import { CommonModule } from '@angular/common';
import { Component, NgModule, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-investmentstatus',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './investmentstatus.component.html',
  styleUrl: './investmentstatus.component.css'
})
export class InvestmentstatusComponent implements OnInit  {
constructor(private route: ActivatedRoute,
  private router: Router,){

}
isSuccess:boolean = false;
backToHome(){
  this.router.navigate(['/home']);
}

retryInvestement(){
  this.router.navigate(['/transact']);
}
ngOnInit() {
  this.route.queryParams.subscribe((param: any) => {
    console.log(param);
    if(param.success){
      this.isSuccess = true;
    }
  })
}
}
