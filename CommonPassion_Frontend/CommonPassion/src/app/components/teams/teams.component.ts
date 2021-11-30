import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { ApiTeam } from '../../models/modelTeam';
import { TeamService } from '../../services/team.service';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {

  modelTeams: ApiTeam;
  leagueId: any;
  

  constructor(
    private teamService: TeamService, 
    private activatedRoute: ActivatedRoute,
    private router: Router) { }

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

}
