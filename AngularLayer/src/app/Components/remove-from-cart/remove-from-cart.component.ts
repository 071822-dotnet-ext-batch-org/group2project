import { Component, OnInit } from '@angular/core';
import { AngularService } from 'src/app/services/ang-service.service'; 

@Component({
  selector: 'app-remove-from-cart',
  templateUrl: './remove-from-cart.component.html',
  styleUrls: ['./remove-from-cart.component.css']
})
export class RemoveFromCartComponent implements OnInit {

  removeproduct: any;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  RemoveFromCart()
  {
    this.AR.putRemoveFromCart(this.removeproduct).then(data => {
      this.removeproduct = data;
    })
  }
}
