import { Component, OnInit } from '@angular/core';
import { AngularService } from 'src/app/services/ang-service.service'; 

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  login: any;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  Login()
  {
    this.AR.postLogin(this.login).then(data => {
      this.login = data;
    })
  }

}
