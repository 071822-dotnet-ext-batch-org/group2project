import { Component, OnInit } from '@angular/core';
import { AngularService } from 'src/app/services/ang-service.service'; 
@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  checkout = this.AR.getItems();

  constructor(private AR: AngularService) { }

  onSubmit(): void {
    //Process checkout data here
    this.checkout = this.AR.clearCart();
    console.warn('Your order has been submitted');
  }

  ngOnInit(): void {
  }

  Checkout()
  {
    
  }

}
