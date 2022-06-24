import { HttpClient } from '@angular/common/http';
import { analyzeAndValidateNgModules } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FixtureService {

  private fixturePath= environment.apiUrl+ '/fixtures/';


  constructor(private http: HttpClient) { }


  getNextClubFixtures( teamId: any, nbFixtures: any = 10   ) :Observable<any>
  {
    return this.http.get(this.fixturePath+ `next/${nbFixtures}/teamId/${teamId}`);
  }

  getFixtureStats(fixtureId: any) : Observable<any>
  {
    return this.http.get(this.fixturePath + `fixtureStats/${fixtureId}`);
  }

  GetH2HFixtures(teamId1 : any, teamId2: any) : Observable<any>
  {
    return this.http.get(this.fixturePath + `h2h/${teamId1}/${teamId2}`);
  }

  GetAllImportantFixtures() : Observable <any>
  {
    return this.http.get(this.fixturePath + 'home');
  }

  GetFixtureByTeam(teamId: any, season: any = environment.CURRENT_SEASON) : Observable<any>
  { 
    return this.http.get(this.fixturePath + `teamId/${teamId}/${season}`);
  }

  GetFixtureByLeague(leagueId: any, season: any = environment.CURRENT_SEASON) : Observable<any>
  {
    return this.http.get(this.fixturePath + `leagueId/${leagueId}`);
  }


  GetTodayFixturesByLeague(leagueId: any) : Observable<any>
  {
    return this.http.get(this.fixturePath + `today/leagueId/${leagueId}`);
  }

  GetLastClubFixtures(teamId: any, nbFixtures: any =20)
  {
    return this.http.get(this.fixturePath+ `last/${nbFixtures}/teamId/${teamId}`);
  }
}
