import { Component, OnInit } from '@angular/core';
import { AngularService } from 'src/app/services/ang-service.service.spec';


@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {

  resetpassword: any;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  ResetPassword()
  {
    this.AR.putResetPassword(this.resetpassword).then(data => {
      this.resetpassword = data;
    })
  }

}
