import { Component, OnInit } from '@angular/core';
import { Checkout } from 'src/app/Models/Checkout';
import { CreateUserProfile } from 'src/app/Models/Create User Profile';
import { AngularService } from 'src/app/services/ang-service.service'; 
import { CreateProductComponent } from '../create-product/create-product.component';
@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  
  checkout = this.AR.getItems();

  orderSubmit: any; 

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
    this.AR.postCheckout(this.orderSubmit).then(data => {
      this.orderSubmit = data;
    })
  }

}
