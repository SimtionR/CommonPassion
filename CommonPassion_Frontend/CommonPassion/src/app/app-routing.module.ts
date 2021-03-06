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
import {StandingComponent} from './components/standing/standing.component';
import { PlayerComponent } from './components/player/player.component';
import {PlayerDetailComponent} from './components/player-detail/player-detail.component';
import { PlayerStandingComponent } from './components/player-standing/player-standing.component';
import { FixtureComponent } from './components/fixture/fixture.component';
import { LeagueFixtureComponent } from './components/league-fixture/league-fixture.component';
import { ProfileComponent } from './components/profile/profile.component';


const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: '', component: HomeComponent},
  {path:'search/:value-searched',component:HomeComponent},
  {path: 'league/:id', component :LeagueDatailComponent},
  {path: 'league_home', component: LeaguesComponent},
  {path: 'team/leagueId/:id', component: TeamsComponent},
  {path: 'team/clubId/:id/:id2', component: TeamDetailComponent},
  {path: 'standing/leagueId/:id', component: StandingComponent},
  {path: 'players/teamId/:id', component: PlayerComponent},
  {path: 'player/playerId/:id', component: PlayerDetailComponent},
  {path: 'playerStanding/leagueId/:id', component: PlayerStandingComponent},
  {path: 'fixtures/clubId/:id', component:FixtureComponent},
  {path: 'leagueFixtures/leagueId/:id', component: LeagueFixtureComponent},
  {path: 'profile', component: ProfileComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
