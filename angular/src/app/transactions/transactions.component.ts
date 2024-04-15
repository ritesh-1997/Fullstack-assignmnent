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
  pspReference: string = 'http://localhost:8080/payment/pg/8be30082-2330-42a0-b6ed-24808fe5cd1b';
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
      }
    })
  }
}
