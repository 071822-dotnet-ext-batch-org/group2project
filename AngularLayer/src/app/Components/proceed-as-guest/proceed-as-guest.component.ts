import { Component, OnInit } from '@angular/core';
import { AngularService } from 'src/app/services/ang-service.service.spec';


@Component({
  selector: 'app-proceed-as-guest',
  templateUrl: './proceed-as-guest.component.html',
  styleUrls: ['./proceed-as-guest.component.css']
})
export class ProceedAsGuestComponent implements OnInit {

  guestaccount: any;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  ProceedAsGuest()
  {
    this.AR.postProceedAsGuest(this.guestaccount).then(data => {
      this.guestaccount = data;
    })
  }
}
