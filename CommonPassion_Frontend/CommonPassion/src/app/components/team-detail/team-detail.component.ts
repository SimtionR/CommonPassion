import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { FixtureService } from '../../services/fixture.service';
import { TeamService } from '../../services/team.service';

@Component({
  selector: 'app-team-detail',
  templateUrl: './team-detail.component.html',
  styleUrls: ['./team-detail.component.css']
})
export class TeamDetailComponent implements OnInit {

  teamDetails: any;
  //routeSub: Subscription;
  leagueId :any;
  clubId:any;
  nextFixtures : any;

  constructor(
    private teamService: TeamService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private fixtureService: FixtureService
    ) { }

  ngOnInit(): void {
    this.clubId= this.activatedRoute.snapshot.paramMap.get('id');
    this.leagueId=this.activatedRoute.snapshot.paramMap.get('id2');
  


    this.teamService.getTeamStatsBySeason(this.clubId,this.leagueId).subscribe(t =>{
      this.teamDetails=t;


      this.fixtureService.getNextClubFixtures(this.clubId).subscribe( f => {
        this.nextFixtures= f;
        console.log(this.nextFixtures);
      });
     
    })
    
    
    
  }

  viewTeam(teamId: any)
  {
    
    this.router.navigate(["players/teamId/", teamId]);
  }

  viewTeamTest()
  {
    console.log("test");
  }

}
