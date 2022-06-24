import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FixtureService } from '../../services/fixture.service';
import * as $ from 'jquery';
import { map } from 'jquery';

@Component({
  selector: 'app-league-fixture',
  templateUrl: './league-fixture.component.html',
  styleUrls: ['./league-fixture.component.css']
})
export class LeagueFixtureComponent implements OnInit {

  public leagueId: any;
  public nextFixtures: any;
  public fixtureRound: string = "Regular Season - 1"


  constructor(
    private fixtureService: FixtureService,
    private activatedRoute : ActivatedRoute) { }

  ngOnInit(): void {

    this.leagueId = this.activatedRoute.snapshot.paramMap.get('id');
    this.fixtureService.GetFixtureByLeague(this.leagueId).subscribe( f =>
      {
        this.nextFixtures = f;
        console.log(f);
      })



      
  }


  

}
