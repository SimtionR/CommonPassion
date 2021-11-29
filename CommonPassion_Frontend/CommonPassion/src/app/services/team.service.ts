import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  private teamPath= environment.apiUrl+'/team/'

  constructor(private http: HttpClient) { }


  getTeamInfoById(id: any) : Observable<any>{

    return this.http.get(this.teamPath +`${id}`);

  }

  getTeamSeasons(id : any) : Observable<any> {
    return this.http.get(this.teamPath+`${id}`);
  } 

  getTeamStatsBySeason(teamId: any, leaugeId: any, season:any) : Observable<any>
  {
    return this.http.get(this.teamPath+`stats/${teamId}&${leaugeId}&${season}`);
  }

  getTeamByLeague(leagueId: any) : Observable<any>
  {
    return this.http.get(this.teamPath+`byLeague/${leagueId}`);
  }


}
