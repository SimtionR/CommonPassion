import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  private playerPath = environment.apiUrl+'/player/';
  constructor(private http: HttpClient) { }

  getPlayerByIdAndSeason(id:any, season: any = 2021): Observable<any>
  {
    return this.http.get(this.playerPath+`playerId/${id}/${season}`);
  }

  getPlayersByGame(game: any)
  {
    return this.http.get(this.playerPath+`${game}`);
  }

  getPlayersByLeagueAndSeason(leagueId:any, season: any = 2021)
  {
    return this.http.get(this.playerPath+`leagueId/${leagueId}/${season}`);
  }

  getPlayersFromTeam(teamId: any, season:any = 2021 )
  {
    return this.http.get(this.playerPath + `teamId/${teamId}/${season}`);
  }

  getPlayerByName(playerName: any, teamId: any, leagueId:any, season: any = 2021)
  {
    return this.http.get(this.playerPath+ `${playerName}/${teamId}&${leagueId}&${season}`);
  }
}
