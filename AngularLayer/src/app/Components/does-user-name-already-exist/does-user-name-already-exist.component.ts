import { Component, OnInit } from '@angular/core';
import { AngularService } from 'src/app/services/ang-service.service'; 

@Component({
  selector: 'app-does-user-name-already-exist',
  templateUrl: './does-user-name-already-exist.component.html',
  styleUrls: ['./does-user-name-already-exist.component.css']
})
export class DoesUserNameAlreadyExistComponent implements OnInit {

  checkusername: any;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  DoesUsernameAlreadyExist()
  {
    this.AR.getUsername().then(data => {
      this.checkusername = data;
    })
  }
}
