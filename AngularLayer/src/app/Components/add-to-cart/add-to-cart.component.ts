import { Component, OnInit } from '@angular/core';
import { AngularService } from 'src/app/services/ang-service.service.spec';

@Component({
  selector: 'app-add-to-cart',
  templateUrl: './add-to-cart.component.html',
  styleUrls: ['./add-to-cart.component.css']
})
export class AddToCartComponent implements OnInit {

  addproduct: any;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  AddToCart()
  {
    this.AR.postAddToCart(this.addproduct).then(data => {
      this.addproduct = data;
    })
  }
}
