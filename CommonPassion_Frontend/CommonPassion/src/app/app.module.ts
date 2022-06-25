import { NgModule } from '@angular/core';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthService } from './services/auth.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HomeComponent } from './components/home/home.component';
import { LeaguesComponent } from './components/leagues/leagues.component';
import { TokenInterceptorService } from './services/token-interceptor.service';
import { LeagueDatailComponent } from './components/league-datail/league-datail.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { GaugeModule } from 'angular-gauge';
import {MatTabsModule} from '@angular/material/tabs';
import {MatIconModule} from '@angular/material/icon';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import {SearchBarComponent} from './components/search-bar/search-bar.component';
import { TeamsComponent } from './components/teams/teams.component';
import { TeamDetailComponent } from './components/team-detail/team-detail.component';
import { StandingComponent } from './components/standing/standing.component';
import { PlayerComponent } from './components/player/player.component';
import { PlayerDetailComponent } from './components/player-detail/player-detail.component';
import { PlayerStandingComponent } from './components/player-standing/player-standing.component';
import { FixtureComponent } from './components/fixture/fixture.component';
import { DatePipe } from '@angular/common';
import { LeagueFixtureComponent } from './components/league-fixture/league-fixture.component';

import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatButtonModule} from '@angular/material/button';
import {MatDividerModule} from '@angular/material/divider';
import { ProfileComponent } from './components/profile/profile.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    LeaguesComponent,
    LeagueDatailComponent,
    SearchBarComponent,
    TeamsComponent,
    TeamDetailComponent,
    StandingComponent,
    PlayerComponent,
    PlayerDetailComponent,
    PlayerStandingComponent,
    FixtureComponent,
    LeagueFixtureComponent,
    ProfileComponent,
   
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    GaugeModule.forRoot(),
    MatFormFieldModule,
    MatTabsModule,
    MatIconModule,
    MatSelectModule,
    MatToolbarModule,
    MatSidenavModule,
    MatButtonModule,
    MatDividerModule

    
  ],
  providers: [
    AuthService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    },
    [DatePipe, FixtureComponent]
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
