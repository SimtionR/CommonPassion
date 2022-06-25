import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Profile } from '../models/profile';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  private profilePath = environment.apiUrl +'/profile/';

  constructor(private http:HttpClient) { }

  getProfileByUserId() : Observable<Profile>
  {

    return this.http.get<Profile>(this.profilePath + 'userProfile');
  }


  uploadProfilePicture(file : FormData) : Observable<any>
  {
    return this.http.post<any>(this.profilePath+'uploadProfile', file);
  }

  getProfilesBySearch(search : string) : Observable<Array<Profile>>
  {
    return this.http.get<Array<Profile>>(this.profilePath + `profiles/${search}`);
  }

  getProfileByProfileId(profileId : number) : Observable<Profile>
  {
    return this.http.get<Profile>(this.profilePath + `profileId/${profileId}`);
  }

}
