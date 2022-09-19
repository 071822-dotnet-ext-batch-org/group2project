import { Component, OnInit } from '@angular/core';
import { AngularService } from 'src/app/services/ang-service.service'; 

@Component({
  selector: 'app-view-previous-orders',
  templateUrl: './view-previous-orders.component.html',
  styleUrls: ['./view-previous-orders.component.css']
})
export class ViewPreviousOrdersComponent implements OnInit {

  vieworders: any;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  ViewPreviousOrders()
  {
    this.AR.getPreviousOrders().then(data => {
      this.vieworders = data;
    })
  }
}
