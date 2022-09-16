import { Component, OnInit } from '@angular/core';
import { AngularService } from 'src/app/services/ang-service.service.spec';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {

  registeruser: any;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  RegisterUser()
  {
    this.AR.postRegisterUser(this.registeruser).then(data =>{
      this.registeruser = data;
    })

  }
}
