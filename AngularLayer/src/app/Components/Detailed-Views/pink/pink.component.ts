import { Component, OnInit } from '@angular/core';
import { AddToCart } from 'src/app/Models/Add To Cart';
import { Product } from 'src/app/Models/Products';
import { AngularService } from 'src/app/services/ang-service.service'; 

@Component({
  selector: 'app-pink',
  templateUrl: './pink.component.html',
  styleUrls: ['./pink.component.css']
})
export class PinkComponent implements OnInit {
  pink: Product | undefined;
  constructor(private AR: AngularService) { }

  ngOnInit(): void {
  }

  AddToCart(pink = {name: 'Pink Dye', amount: 100, color: 'Pink', price: 10})
  {
    this.AR.AddToCart(pink);
    }

}
