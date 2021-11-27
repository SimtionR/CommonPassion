import { Component, OnInit } from '@angular/core';
import { RootLeague } from '../../models/RootLeague';
import { LeaguesService } from '../../services/leagues.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-league-datail',
  templateUrl: './league-datail.component.html',
  styleUrls: ['./league-datail.component.css']
})
export class LeagueDatailComponent implements OnInit {

  league: RootLeague;

  constructor(private leagueService:LeaguesService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    const id= this.route.snapshot.paramMap.get('id');
    console.log(id);
    this.leagueService.getLeagueById(id).subscribe(l=>
      this.league=l);
    
  
  }

}

