import { Component, OnInit } from '@angular/core';
import { AngularService } from 'src/app/services/ang-service.service.spec';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  checkout: any;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  Checkout()
  {
    this.AR.postCheckout(this.checkout).then(data => {
      this.checkout = data;
    })
  }

}
