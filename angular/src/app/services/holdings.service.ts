import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IHoldingsResponse } from '../Models/interfaces';

@Injectable({
  providedIn: 'root'
})
export class HoldingsService {

  constructor(private http:HttpClient) { }
  getHoldings(payload:any,phoneNumber:string){
    return this.http.post<IHoldingsResponse[]>(`http://localhost:5151/api/order/GetHoldings/${phoneNumber}`,payload);

  }
  getHolding(payload:any){
    return this.http.post<IHoldingsResponse[]>(`http://localhost:5151/api/order/GetHolding`,payload);

  }
}
