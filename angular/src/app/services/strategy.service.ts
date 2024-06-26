import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IInvestmentStrategy } from '../Models/interfaces';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { of } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class StrategyService {

  constructor(private http:HttpClient) { }
  investmentStrategies():Observable<any> { 
    return this.http.get(`http://localhost:5151/api/userinvestment/getinvestmentstrategies`)
  }
  }

