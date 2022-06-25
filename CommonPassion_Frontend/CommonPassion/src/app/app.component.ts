import { Component, OnInit, ViewChild } from '@angular/core';
import {MatSidenav} from '@angular/material/sidenav';
import {BreakpointObserver} from '@angular/cdk/layout';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Profile } from './models/profile';
import { ProfileService } from './services/profile.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;
  profile: Profile;
  blob : string;

  constructor(private observer: BreakpointObserver,
              private router: Router,
              private profileService: ProfileService){

  }

  ngOnInit(): void {
    console.log("app cmp was called");
     this.profileService.getProfileByUserId().subscribe( p =>{
       this.profile = p;
       this.blob = "https://blobmoviebase.blob.core.windows.net/profilepictures/" + p.profilePicture;
     })
  }

  ngAfterViewInit(){
    // this.observer.observe(['(max-width: 800px)']).subscribe((res) => {
    //   if(res.matches){
    //     this.sidenav.mode='over';
    //     this.sidenav.close();
    //   } else {
    //     this.sidenav.mode='side';
    //     this.sidenav.open()
    //   }
    // });
  }

  onSubmit(form: NgForm){
    this.router.navigate(['search',form.value.search])
    console.log("search was called");
    
  }

  openProfile()
  {
    this.router.navigate(['/profile']);
    
  }

  openHome()
  {
    this.router.navigate(['/']);
  }
  openChat()
  {
    this.router.navigate(['chat']);
  } 
}
