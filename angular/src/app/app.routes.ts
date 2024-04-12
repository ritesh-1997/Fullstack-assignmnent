import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { TransactComponent } from './transact/transact.component';
import { HoldingsComponent } from './holdings/holdings.component';
import { HomepageComponent } from './homepage/homepage.component';

export const routes: Routes = [
    {path: '', component: LoginComponent},
    {path: 'login', component: LoginComponent},
    {path: 'transact', component: TransactComponent},
    {path: 'holdings',component: HoldingsComponent},
    {path: 'home', component: HomepageComponent}
  ];