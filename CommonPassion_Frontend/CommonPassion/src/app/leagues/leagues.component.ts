import { CompileShallowModuleMetadata } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { RootLeague } from '../models/RootLeague';
import { LeaguesService } from '../services/leagues.service';

@Component({
  selector: 'app-leagues',
  templateUrl: './leagues.component.html',
  styleUrls: ['./leagues.component.css']
})
export class LeaguesComponent implements OnInit {

  leagueApi: RootLeague;


  constructor(private leagueService: LeaguesService) { }

  ngOnInit(): void {
     this.leagueService.getLeagueById(39).subscribe(l=> 
     {
      this.leagueApi=l;
      console.log(this.leagueApi);
     }
       );

       //console.log(this.league);
       
  }


  getLeagueById()
  {
    return this.leagueService.getLeagueById(39).subscribe(c => console.log(c))
    
  }

  getAllLeagues()
  {
    return this.leagueService.getLeagues().subscribe( c => console.log(c));
  }

  

}
