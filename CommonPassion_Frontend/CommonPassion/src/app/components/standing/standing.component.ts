import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { ApiStanding } from '../../models/api_standing';
import { StandingsService } from '../../services/standings.service';

@Component({
  selector: 'app-standing',
  templateUrl: './standing.component.html',
  styleUrls: ['./standing.component.css']
})
export class StandingComponent implements OnInit {


  standingLeague$: Observable<ApiStanding>;
  standingTeam: ApiStanding;
  teamId: any;
  leagueId:any;
  standingLeague: ApiStanding;
  test="#00ff00";
  constructor(private standingService: StandingsService,private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {

    this.teamId= this.activatedRoute.snapshot.paramMap.get('id');
    this.leagueId= this.activatedRoute.snapshot.paramMap.get('id2');

    this.standingService.getStandingByTeam(this.teamId).subscribe(s =>{
      this.standingTeam=s;
      console.log(this.standingTeam);
    })
    
    this.standingService.getStandingByLeague(this.leagueId).subscribe(s =>{
      this.standingLeague=s;
      console.log(this.standingLeague);
    })

    
  }

  getColor(value: string) :string{
    if( value =="Promotion - Champions League (Group Stage)"){
      
      return '#4d4dff';
    }
    else if(value =="Promotion - Europa League (Group Stage)")
    {
      //verifica de ce apar mai multe console log uri in if-uri la debug
      return '#ffff00';
    }
    else if (value =="Promotion - Europa Conference League (Qualification)")
    { 
      
      return "#ffff99";
     
    }
    else if (value?.includes("Relegation"))
    {
      
      return  "#990000;"
    }
   
    else return "#ffffff";
  }

}
