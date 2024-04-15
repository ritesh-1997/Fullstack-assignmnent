import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IHoldingsResponse, IUserHoldingsRequest } from '../Models/interfaces';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HoldingsService {

  constructor(private http:HttpClient) { }
  getHoldings(payload:any,phoneNumber:string):Observable<IUserHoldingsRequest>{
    return this.http.post<IUserHoldingsRequest>(`http://localhost:5151/api/order/GetHoldings/${phoneNumber}`,payload);

  }
  getHolding(payload:any):Observable<IHoldingsResponse[]>{
    return this.http.post<IHoldingsResponse[]>(`http://localhost:5151/api/order/GetHolding`,payload);

  }
}
