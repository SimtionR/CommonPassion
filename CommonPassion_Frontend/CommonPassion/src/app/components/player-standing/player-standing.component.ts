import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router'

@Component({
  selector: 'app-player-standing',
  templateUrl: './player-standing.component.html',
  styleUrls: ['./player-standing.component.css']
})
export class PlayerStandingComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
  }

}
