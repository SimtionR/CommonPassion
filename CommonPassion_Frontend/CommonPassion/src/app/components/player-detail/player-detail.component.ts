import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {PlayerService} from '../../services/player.service';

@Component({
  selector: 'app-player-detail',
  templateUrl: './player-detail.component.html',
  styleUrls: ['./player-detail.component.css']
})
export class PlayerDetailComponent implements OnInit {


  playerId: any;
  playerDetails: any;

  constructor(private playerService: PlayerService,
              private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.playerId= this.activatedRoute.snapshot.paramMap.get('id');

    this.playerService.getPlayerByIdAndSeason(this.playerId).subscribe( p =>{
      this.playerDetails= p;
      console.log(p);
    })
  }

}
