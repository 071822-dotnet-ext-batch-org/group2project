import { Component, OnInit } from '@angular/core';
import { AngularService } from 'src/app/services/ang-service.service'; 

@Component({
  selector: 'app-is-account-admin',
  templateUrl: './is-account-admin.component.html',
  styleUrls: ['./is-account-admin.component.css']
})
export class IsAccountAdminComponent implements OnInit {

  checkadmin: any;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  IsAccountAdmin()
  {
    this.AR.getAdminAccount().then(data => {
      this.checkadmin = data;
    })
  }
}
