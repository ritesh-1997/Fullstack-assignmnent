import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { HoldingsComponent } from './holdings/holdings.component';
import { TransactComponent } from './transact/transact.component';

export const routes: Routes = [
    {path: '', component: LoginComponent},
    {path: 'login', component: LoginComponent},
    {path: 'home', component: HomeComponent},
    {path: 'holding', component: HoldingsComponent},
    {path: 'transact', component: TransactComponent}
    
  ];