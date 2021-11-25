import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LeaguesService {

  // public var leagueId=0;

  private leaguePath= environment.apiUrl + `/league/`;


  constructor(private http :HttpClient) { }


  getLeagueById(leagueId:any) :Observable<any>{
    return this.http.get(this.leaguePath +`${leagueId}`);
  }

  getLeagues() : Observable<any> {
    return this.http.get(this.leaguePath+'all');
  }

  getImportantLeagues() : Observable<any>
  {
    return this.http.get(this.leaguePath+'home');
  }
}
