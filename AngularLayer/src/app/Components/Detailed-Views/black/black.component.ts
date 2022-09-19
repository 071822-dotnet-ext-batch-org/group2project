import { Component, OnInit } from '@angular/core';
import { AddToCart } from 'src/app/Models/Add To Cart';
import { Product } from 'src/app/Models/Products';
import { AngularService } from 'src/app/services/ang-service.service'; 

@Component({
  selector: 'app-black',
  templateUrl: './black.component.html',
  styleUrls: ['./black.component.css']
})
export class BlackComponent implements OnInit {
  black: Product | undefined;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  AddToCart(black = {name: 'BlackDye', amount: 100, color: 'Black', price: 10})
  {
    this.AR.AddToCart(black);
    }
}
