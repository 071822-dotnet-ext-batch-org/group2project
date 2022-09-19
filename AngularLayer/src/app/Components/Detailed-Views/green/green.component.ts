import { Component, OnInit } from '@angular/core';
import { AddToCart } from 'src/app/Models/Add To Cart';
import { Product } from 'src/app/Models/Products';
import { AngularService } from 'src/app/services/ang-service.service'; 


@Component({
  selector: 'app-green',
  templateUrl: './green.component.html',
  styleUrls: ['./green.component.css']
})
export class GreenComponent implements OnInit {
  green: Product | undefined;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  AddToCart(green = {name: 'Green Dye', amount: 100, color: 'Black', price: 10})
  {
    this.AR.AddToCart(green);
    }
}
