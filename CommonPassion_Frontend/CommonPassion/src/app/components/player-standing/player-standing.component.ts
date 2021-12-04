import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router'
import { PlayerStandingService } from '../../services/player-standing.service';

@Component({
  selector: 'app-player-standing',
  templateUrl: './player-standing.component.html',
  styleUrls: ['./player-standing.component.css']
})
export class PlayerStandingComponent implements OnInit {

  leagueId: any;
  playerStanding: any;
  sort: string="Goals";

  constructor(private activatedRoute: ActivatedRoute,
              private playerStandingService: PlayerStandingService,
              private router: Router) { }

  ngOnInit(): void {

    this.leagueId = this.activatedRoute.snapshot.paramMap.get('id');
    this.selectStanding(this.sort);

  }

  selectStanding(sort: string)
  {

    
    
    if( sort?.toString() == "Goals")
    {
      this.playerStandingService.getBestScorers(this.leagueId).subscribe(s =>{
        this.playerStanding=s;
        console.log(s);
        
      })
    }


    else if ( sort == "Assists")
    {
      this.playerStandingService.getMostAssits(this.leagueId).subscribe(a =>{
        this.playerStanding=a;
       
      })
    }

    else if (sort == "Yellow Cards")
    {
      this.playerStandingService.getMostYellowCards(this.leagueId).subscribe(y =>{
        this.playerStanding=y;
     
      })
    }

    else if (sort == "Red Cards")
    {
      
      this.playerStandingService.getMostRedCards(this.leagueId).subscribe(r =>{
        this.playerStanding=r;
      
    })
  }    
  }

  displayPlayer(playerId: any)
  {
    this.router.navigate(["player/playerId/", playerId]);
  }

  }
