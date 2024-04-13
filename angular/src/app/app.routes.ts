import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { TransactComponent } from './transact/transact.component';


export const routes: Routes = [
    {path: '', component: LoginComponent},
    {path: 'login', component: LoginComponent},

  ];