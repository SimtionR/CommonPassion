import { Component, OnInit } from '@angular/core';
import { FixtureService } from '../../services/fixture.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-fixture',
  templateUrl: './fixture.component.html',
  styleUrls: ['./fixture.component.css']
})
export class FixtureComponent implements OnInit {

  constructor(private fixtureService: FixtureService,
              private router: Router) { }

  ngOnInit(): void {
  }

}
