import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { FixtureComponent } from '../fixture/fixture.component';
import { ApiTeam } from '../../models/api_team'
import { TeamService } from '../../services/team.service';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {

  modelTeams: any;
  leagueId: any;


  constructor(
    private teamService: TeamService, 
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private fixtureComponent: FixtureComponent) { }

  ngOnInit(): void {
    this.leagueId= this.activatedRoute.snapshot.paramMap.get('id');
    this.teamService.getTeamByLeague(this.leagueId).subscribe(t=> {
      this.modelTeams=t;
      console.log(t);
    });
  }


  openTeamDetails(id: any)
  {
    console.log("works");
    this.router.navigate(['team/clubId/', id]);
  }

  openTeamDetails2(id:any, leagueId:any)
  {
    this.router.navigate(['team/clubId/',id, leagueId]);
   
  }

  viewStanding(leagueId:any )
  {
      this.router.navigate(['standing/leagueId/',leagueId]);
      console.log(this.leagueId);
      console.log(leagueId);
  }

  viewPlayerStats(leagueId: any)
  {
    this.router.navigate(['playerStanding/leagueId/',leagueId]);
  }

  viewLastResults(clubId:any)
  {
    this.fixtureComponent.sort = "last";
    this.router.navigate(['fixtures/clubId/',clubId]);
    
  }

}
