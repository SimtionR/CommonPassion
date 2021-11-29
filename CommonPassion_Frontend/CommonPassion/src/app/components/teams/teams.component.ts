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

  constructor(
    private teamService: TeamService, 
    private activatedRoute: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.teamService.getTeamByLeague(140).subscribe(t=> {
      this.modelTeams=t;
      console.log(t);
    });
  }


  openTeamDetails(id: any)
  {
    console.log("works");
    this.router.navigate(['team/clubId/', id]);
  }

}
