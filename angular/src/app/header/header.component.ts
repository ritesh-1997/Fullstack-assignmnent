import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {
  user:string = "";
  isUserLoggedIn:boolean = false;
  ngOnInit() {
    this.user = localStorage.getItem('Authorization')?.toString()??'';
    console.log(this.user);
    if(this.user.length > 0) {}
      this.isUserLoggedIn=true;
  }
}
