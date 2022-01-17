import { Component, OnInit } from '@angular/core';
import { FixtureService } from '../../services/fixture.service';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-fixture',
  templateUrl: './fixture.component.html',
  styleUrls: ['./fixture.component.css']
})
export class FixtureComponent implements OnInit {

  clubId: any;
  nextFixtures : any;

  constructor(private fixtureService: FixtureService,
              private router: Router,
              private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.clubId= this.activatedRoute.snapshot.paramMap.get('id');

    this.fixtureService.getNextClubFixtures(this.clubId).subscribe( f => {
      this.nextFixtures= f;
      console.log(this.nextFixtures);
    });
   

  }

}
