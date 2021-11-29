import { Component, OnInit } from '@angular/core';
import { TeamService } from '../../services/team.service';
import {ActivatedRoute} from '@angular/router'
import { ApiTeam } from '../../models/modelTeam';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  sort:string;
  modelTeams: ApiTeam;

  constructor(private teamService: TeamService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
   
  }

}
