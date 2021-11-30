import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import {HomeComponent} from './components/home/home.component';
import { LeaguesComponent } from './components/leagues/leagues.component';
import { LeagueDatailComponent } from './components/league-datail/league-datail.component';
import { SearchBarComponent } from './components/search-bar/search-bar.component';
import {TeamDetailComponent} from './components/team-detail/team-detail.component';
import {TeamsComponent} from './components/teams/teams.component';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: '', component: HomeComponent},
  {path:'search/:value-searched',component:HomeComponent},
  {path: 'league/:id', component :LeagueDatailComponent},
  {path: 'league_home', component: LeaguesComponent},
  {path: 'team/leagueId/:id', component: TeamsComponent},
  {path: 'team/clubId/:id/:id2', component: TeamDetailComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
