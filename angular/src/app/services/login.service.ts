import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http:HttpClient) { }
  login(phonenumber:string){
    return this.http.post(`http://localhost:5151/api/userinvestment/investment`,phonenumber);
  }
}
