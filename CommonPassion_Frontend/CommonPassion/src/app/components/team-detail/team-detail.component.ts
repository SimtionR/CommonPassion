import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { FixtureService } from '../../services/fixture.service';
import { ResultService } from '../../services/result.service';
import { TeamService } from '../../services/team.service';
import { FixtureComponent } from '../fixture/fixture.component';

@Component({
  selector: 'app-team-detail',
  templateUrl: './team-detail.component.html',
  styleUrls: ['./team-detail.component.css']
})
export class TeamDetailComponent implements OnInit {

  teamDetails: any;
 
  leagueId :any;
  clubId:any;
 

  constructor(
    private teamService: TeamService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private fixtureComponenet : FixtureComponent,
    private resultService : ResultService
   
    ) { }

  ngOnInit(): void {
    this.clubId= this.activatedRoute.snapshot.paramMap.get('id');
    this.leagueId=this.activatedRoute.snapshot.paramMap.get('id2');
    this.resultService.updateSort("next");
  


    this.teamService.getTeamStatsBySeason(this.clubId,this.leagueId).subscribe(t =>{
      this.teamDetails=t
      console.log(this.teamDetails);


     
     
    })
    
    
    
  }

  viewTeam(teamId: any)
  {
    
    this.router.navigate(["players/teamId/", teamId]);
  }

  viewLastResults(clubId: any)
  {
    this.resultService.updateSort("last");
    this.router.navigate(["fixtures/clubId/",clubId]);
  }


}
