import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PlayerService } from '../../services/player.service';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {
  teamId: any;

  players: any;
  constructor(private playerService: PlayerService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.teamId= this.activatedRoute.snapshot.paramMap.get('id');

    this.playerService.getPlayersFromTeam(this.teamId).subscribe(p =>
      {
        this.players= p;
        console.log(p);
      })


  }

}
