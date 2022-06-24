import { Component, OnInit } from '@angular/core';
import { FixtureService } from '../../services/fixture.service';
import {ActivatedRoute, Router} from '@angular/router';
import { ResultService } from '../../services/result.service';
import { CompileShallowModuleMetadata } from '@angular/compiler';

@Component({
  selector: 'app-fixture',
  templateUrl: './fixture.component.html',
  styleUrls: ['./fixture.component.css']
})
export class FixtureComponent implements OnInit {

  clubId: any;
  nextFixtures : any;
  sort : string;

  constructor(private fixtureService: FixtureService,
              private router: Router,
              private activatedRoute: ActivatedRoute,
              private resultService : ResultService) { }

  ngOnInit(): void {
    this.clubId= this.activatedRoute.snapshot.paramMap.get('id');

   
   this.sort= this.resultService.returnSort();
  
   if(this.sort == null)
   {
     this.sort="last";
   } 
   
   


    
    this.selectFixtures(this.sort);
    

  }

  selectFixtures(sort:string)
  {

    
    if(sort == "next")
    {
      this.fixtureService.getNextClubFixtures(this.clubId).subscribe( f => {
        this.nextFixtures= f;
        console.log(this.nextFixtures);
      });
    }

    else if(sort =="last")
    {
      this.fixtureService.GetLastClubFixtures(this.clubId).subscribe( f => {
        this.nextFixtures= f;
        console.log(this.nextFixtures);
      });
    }

    else if(sort= "league")
    {

      this.fixtureService.GetLastClubFixtures(this.clubId).subscribe( f => {
        this.nextFixtures = f;
        console.log(this.nextFixtures);
      })

    }

    
  }

}
