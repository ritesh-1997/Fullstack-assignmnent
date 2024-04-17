import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IInvestment, IInvestmentStrategy } from '../Models/interfaces';

@Injectable({
  providedIn: 'root'
})
export class InvestService {

  constructor(private http:HttpClient) { }
  invest(payload:any):Observable<IInvestmentStrategy[]> { 
    return this.http.post<IInvestmentStrategy[]>(`http://localhost:5151/api/payment/createorder`,payload);
  }

  buyfunds(payload:any={}):Observable<IInvestment> { 
    return this.http.post<IInvestment>(`http://localhost:5151/api/order/buystrategyfunds`,payload);
  }
}
