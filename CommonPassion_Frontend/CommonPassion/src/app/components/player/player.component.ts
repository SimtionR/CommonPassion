import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PlayerService } from '../../services/player.service';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {
  teamId: any;

  players: any;
  constructor(private playerService: PlayerService,
              private activatedRoute: ActivatedRoute,
              private router : Router) { }

  ngOnInit(): void {
    this.teamId= this.activatedRoute.snapshot.paramMap.get('id');

    this.playerService.getPlayersFromTeam(this.teamId).subscribe(p =>
      {
        this.players= p;
        console.log(p);
      })


  }

  openPlayerDetails(id: any)
  {
    
    this.router.navigate(['player/playerId/', id]);
  }

}
