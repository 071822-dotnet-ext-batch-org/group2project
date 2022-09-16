import { Component, OnInit } from '@angular/core';
import { AngularService } from 'src/app/services/ang-service.service.spec';


@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {

  editprofile: any;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  EditProfile()
  {
    this.AR.putEditProfile(this.editprofile).then(data => {
      this.editprofile = data;
    })
  }

}
