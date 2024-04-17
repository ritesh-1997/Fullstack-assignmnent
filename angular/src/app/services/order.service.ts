import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IInvestment } from '../Models/interfaces';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http:HttpClient) { }
  retryInvestement():Observable<IInvestment>{
    return this.http.get<IInvestment>(`http://localhost:5151/api/order/FetchInvestmentDetails`);
  }
}
