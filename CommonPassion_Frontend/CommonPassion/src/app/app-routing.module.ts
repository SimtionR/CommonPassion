import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import {HomeComponent} from './components/home/home.component';
import { LeaguesComponent } from './components/leagues/leagues.component';
import { LeagueDatailComponent } from './components/league-datail/league-datail.component';
import { SearchBarComponent } from './components/search-bar/search-bar.component';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: '', component: HomeComponent},
  {path:'search/:value-searched',component:HomeComponent},
  {path: 'league/:id', component :LeagueDatailComponent},
  {path: 'league_home', component: LeaguesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
