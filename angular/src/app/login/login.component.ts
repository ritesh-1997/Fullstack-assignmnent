import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit{
  phoneNumber: string = '';
  constructor(private loginService: LoginService,
    private router: Router
   ){
  
   }
 ngOnInit() {
     // get data from local storage
     if(localStorage.getItem('Authorization')){
      this.router.navigate(['/home']);
     }
 }
 login(phoneNumber:string){
  const payload = {phoneNumber:phoneNumber};
  this.loginService.login(payload).subscribe((response:any)=>{
    if(response.success){
      //save to local storage
      localStorage.setItem('Authorization', this.phoneNumber);
      this.router.navigate(['/home']);
    }
    else{
      this.router.navigate(['/login']);
    }
  });
 }

}
