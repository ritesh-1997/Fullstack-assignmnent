import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-transactions',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './transactions.component.html',
  styleUrl: './transactions.component.css'
})
export class TransactionsComponent implements OnInit {
  pspReference: string = '';
  isSuccess: boolean = true;
  constructor(private route: ActivatedRoute,
    private router: Router,
  ){}

  
  ngOnInit() {
    this.route.queryParams.subscribe((param: any) => {
      console.log(param);
      if(param.success){
        this.isSuccess = true;
        this.pspReference = param.paymentLink;
        // this.navigateToExternalUrl(param.paymentLink);
      }
      else{

      }
    })
  }

  backToHome(){
    this.router.navigate(['/home']);
  }
}
