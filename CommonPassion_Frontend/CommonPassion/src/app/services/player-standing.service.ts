import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PlayerStandingService {

  standingPath= environment.apiUrl+'/playerStanding/';
  constructor(private http : HttpClient) { }


  getBestScorers(leagueId: any, season: any = environment.CURRENT_SEASON)
  {
    return this.http.get(this.standingPath+ `scorers/${leagueId}/${season}`);
  }

  getMostAssits(leagueId: any, season: any = environment.CURRENT_SEASON)
  {
    return this.http.get(this.standingPath +`mostAssits/${leagueId}/${season}`);
  }

  getMostYellowCards(leagueId: any, season: any = environment.CURRENT_SEASON)
  {
    return this.http.get(this.standingPath+`yellowCards/${leagueId}/${season}`);
  }

  getMostRedCards(leagueId: any, season : any = environment.CURRENT_SEASON)
  {
    return this.http.get(this.standingPath+`redCards/${leagueId}/${season}`);
  }
}
