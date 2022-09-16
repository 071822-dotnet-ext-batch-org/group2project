import { Component, OnInit } from '@angular/core';
import { AngularService } from 'src/app/services/ang-service.service.spec';

@Component({
  selector: 'app-create-user-profile',
  templateUrl: './create-user-profile.component.html',
  styleUrls: ['./create-user-profile.component.css']
})
export class CreateUserProfileComponent implements OnInit {

  newuser: any;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  CreateUserProfile()
  {
    this.AR.getCreateUserProfile().then(data => {
      this.newuser = data;
    })
  }
}
