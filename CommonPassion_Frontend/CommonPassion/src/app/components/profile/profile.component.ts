import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Profile } from '../../models/profile';
import { ProfileService } from '../../services/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  profile: Profile;
  selectedPhoto: File;
  profileForm: FormGroup;
  blob : string;

  constructor(private router: Router,
    private profileSerice: ProfileService) { }

    ngOnInit(): void {
      this.profileForm = new FormGroup({
        profileImage :new FormControl(null)
      }); 
  
      this.profileSerice.getProfileByUserId().subscribe(p =>
        {
          this.profile = p;
          this.blob ="https://blobmoviebase.blob.core.windows.net/profilepictures/" + p.profilePicture;
          console.log(this.blob);
          
        })
    }

    onFileChange(e: any) {
      //  console.log(e);
      //  this.selectedPhoto!.file = (<HTMLInputElement>e.target).files![0];
      this.selectedPhoto = <File>e.target.files[0];
      }


      onSubmit()
      {
        const formData = new FormData();
        // formData.append(this.selectedPhoto.name, this.selectedPhoto.file);
    
        formData.append('Name', this.selectedPhoto.name);
        formData.append('File', this.selectedPhoto);
        this.profileSerice.uploadProfilePicture(formData).subscribe(c =>
          {
            window.location.replace(window.location.href);
          });
    
        
      }

      openMyConnections(id:any)
      {
        this.router.navigate([`myConnections/${id}`]);
      }

}
