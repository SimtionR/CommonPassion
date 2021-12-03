import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StandingsService {

  private standingPath= environment.apiUrl+ '/standing/';

  constructor(private httpClient: HttpClient) { }


  getStandingByTeam (teamId: any, season: any =environment.CURRENT_SEASON) : Observable<any>
  {
    return this.httpClient.get(this.standingPath+ `team/${teamId}/${season}`);
  }

  getStandingByLeague(leagueId:any, season: any =environment.CURRENT_SEASON) : Observable<any>
  {
    return this.httpClient.get(this.standingPath+`league/${leagueId}/${season}`);
  }
}
