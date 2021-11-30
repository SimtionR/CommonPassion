import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
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

  constructor(
    private teamService: TeamService,
    private activatedRoute: ActivatedRoute
    ) { }

  ngOnInit(): void {
    this.clubId= this.activatedRoute.snapshot.paramMap.get('id');
    this.leagueId=this.activatedRoute.snapshot.paramMap.get('id2');
  


    this.teamService.getTeamStatsBySeason(this.clubId,this.leagueId).subscribe(t =>{
      this.teamDetails=t;
      console.log(this.teamDetails);
    })
    
    
    
  }

}
